using System.Diagnostics;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Backsolate
{
    public partial class MainForm : Form
    {
        private Bitmap originalImage;
        private Bitmap? processedImage;

        static string modelUrl = "https://github.com/danielgatis/rembg/releases/download/v0.0.0/u2net.onnx";
        string modelPath = Path.Combine(Application.StartupPath, Path.GetFileName(modelUrl));
        string selectedModel = "u2net";

        string originalFileName = "picture";
        string imageInfo = "No image is loaded. Load an image to view its resolution and filesize here...";

        public MainForm()
        {
            InitializeComponent();

            originalImage = new Bitmap(pictureBoxOriginal.Width, pictureBoxOriginal.Height);
            processedImage = null;

            foreach (var model in ModelCatalog.Models)
            {
                modelSelect.DropDown.Items.Add(model.Key);
            }
        }

        private async Task DownloadModelAsync(string url, string destinationPath)
        {
            progressBar.Value = 0;

            if (!File.Exists(modelPath))
            {
                using (HttpClient client = new HttpClient())
                {
                    lblInfoText.Text = "Downloading model...";

                    using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        long totalBytes = response.Content.Headers.ContentLength ?? -1;
                        long receivedBytes = 0;

                        using (var fs = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            DateTime startTime = DateTime.Now;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fs.WriteAsync(buffer, 0, bytesRead);
                                receivedBytes += bytesRead;

                                TimeSpan elapsedTime = DateTime.Now - startTime;

                                if (totalBytes > 0)
                                {
                                    int progressPercentage = (int)(receivedBytes * 100 / totalBytes);
                                    progressBar.Value = progressPercentage;

                                    double speed = receivedBytes / elapsedTime.TotalSeconds;
                                    lblInfoText.Text = $"Downloading model... ({FormatFileSize(receivedBytes)}/{FormatFileSize(totalBytes)}) [{progressPercentage}%] Speed: {FormatFileSize((long)speed)}/s";
                                    Update();
                                }
                            }
                        }
                    }

                    lblInfoText.Text = "Model downloaded successfully!";
                    progressBar.Value = 100;
                }
            }
        }

        private async void btnRemoveBackground_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            try
            {
                btnRemoveBackground.Enabled = false;
                modelSelect.Enabled = false;

                modelPath = Path.Combine(Application.StartupPath, Path.GetFileName(modelUrl));

                await DownloadModelAsync(modelUrl, modelPath);

                Stopwatch stopwatch = Stopwatch.StartNew();

                progressBar.Value = 0;
                processedImage = await RemoveBackgroundAsync(originalImage);
                pictureBoxProcessed.Image = processedImage;

                stopwatch.Stop();

                TimeSpan elapsedTime = stopwatch.Elapsed;

                string elapsedTimeString = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds / 10);

                ShowUpdate($"Done. (Took {elapsedTimeString})", 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar.Value = 0;
            }
            finally
            {
                btnRemoveBackground.Enabled = true;
                modelSelect.Enabled = true;
            }
        }

        private void ShowUpdate(string msg, int pbIncrement)
        {
            lblInfoText.Text = msg;
            progressBar.Value += pbIncrement;
            Update();
        }

        private async void RedownloadModelAsk()
        {
            var result = MessageBox.Show(
                "Would you like to redownload the model? The current model file may be corrupt.",
                "Unexpected Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                lblInfoText.Text = "Attempting to download the model again...";
                try
                {
                    await DownloadModelAsync(modelUrl, modelPath);
                    lblInfoText.Text = "Model downloaded successfully!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while downloading the model: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<Bitmap> RemoveBackgroundAsync(Bitmap image)
        {
            try
            {
                ShowUpdate($"Preparing model session ({selectedModel})...", 0);

                return await Task.Run(() =>
                {
                    using var session = new InferenceSession(modelPath);

                    var inputName = session.InputMetadata.Keys.FirstOrDefault();
                    var outputName = session.OutputMetadata.Keys.FirstOrDefault();

                    if (string.IsNullOrEmpty(inputName) || string.IsNullOrEmpty(outputName))
                        throw new InvalidOperationException("Model input or output names could not be determined.");

                    ShowUpdate("Preprocessing image...", 20);
                    var inputTensor = PreprocessImage(image);

                    ShowUpdate("Running model...", 20);
                    var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor(inputName, inputTensor) };
                    using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = session.Run(inputs);

                    ShowUpdate("Postprocessing image...", 20);
                    var mask = PostprocessMask(results.First().AsTensor<float>(), image.Width, image.Height);

                    ShowUpdate("Applying alpha mask...", 20);
                    return ApplyMask(image, mask);
                });
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Model file not found. Please check if the model file exists and is in the correct location.",
                                "Model File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RedownloadModelAsk();

                progressBar.Value = 0;
            }
            catch (OnnxRuntimeException ex)
            {
                MessageBox.Show($"An error occurred while running the ONNX model:\n{ex.Message}",
                                "Model Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                progressBar.Value = 0;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"An invalid operation occurred:\n{ex.Message}",
                                "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred:\n{ex.Message}",
                                "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                progressBar.Value = 0;
            }

            return image;
        }

        private DenseTensor<float> PreprocessImage(Bitmap image)
        {
            int size = ModelCatalog.ModelPreferredSize[selectedModel];
            Bitmap resizedImage = new Bitmap(image, new Size(size, size));
            DenseTensor<float> tensor = new DenseTensor<float>(new[] { 1, 3, size, size });

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Color pixel = resizedImage.GetPixel(x, y);
                    tensor[0, 0, y, x] = pixel.R / 255f;
                    tensor[0, 1, y, x] = pixel.G / 255f;
                    tensor[0, 2, y, x] = pixel.B / 255f;
                }
            }

            return tensor;
        }

        private float[,] PostprocessMask(Tensor<float> mask, int originalWidth, int originalHeight)
        {
            var maskData = mask.ToArray();
            var resizedMask = new float[originalHeight, originalWidth];

            float scaleX = (float)mask.Dimensions[3] / originalWidth;
            float scaleY = (float)mask.Dimensions[2] / originalHeight;

            for (int y = 0; y < originalHeight; y++)
            {
                for (int x = 0; x < originalWidth; x++)
                {
                    int srcX = (int)(x * scaleX);
                    int srcY = (int)(y * scaleY);
                    resizedMask[y, x] = maskData[srcY * mask.Dimensions[3] + srcX];
                }
            }

            return resizedMask;
        }

        private Bitmap ApplyMask(Bitmap image, float[,] mask)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    float alpha = mask[y, x];
                    result.SetPixel(x, y, Color.FromArgb((int)(alpha * 255), pixel.R, pixel.G, pixel.B));
                }
            }
            return result;
        }

        private void OpenImageFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalFileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBoxOriginal.Image = originalImage;

                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    imageInfo = $"Input Resolution: {originalImage.Size.Width}x{originalImage.Size.Height}\nInput File Size: {FormatFileSize(fileInfo.Length)}";
                }
            }
        }

        private void SaveImageFile()
        {
            if (processedImage == null)
            {
                MessageBox.Show("No processed image to save. To remove background from an image, please click on the box above the label 'Original Image'.", "Can't save resultant image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.FileName = $"{originalFileName}-removed-bg.png";
                saveFileDialog.Title = "Save image as...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    processedImage.Save(saveFileDialog.FileName);
                }
            }
        }

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {
            OpenImageFile();
        }

        private string FormatFileSize(long bytes)
        {
            const long kb = 1024;
            const long mb = kb * 1024;
            const long gb = mb * 1024;

            if (bytes >= gb)
            {
                return $"{(double)bytes / gb:F2} GB";
            }
            else if (bytes >= mb)
            {
                return $"{(double)bytes / mb:F2} MB";
            }
            else if (bytes >= kb)
            {
                return $"{(double)bytes / kb:F2} KB";
            }
            else
            {
                return $"{bytes} bytes";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originalImage = new Bitmap(pictureBoxOriginal.Width, pictureBoxOriginal.Height);
            processedImage = new Bitmap(pictureBoxProcessed.Width, pictureBoxProcessed.Height);
            pictureBoxOriginal.Image = originalImage;
            pictureBoxProcessed.Image = processedImage;

            imageInfo = "No image is loaded. Load an image to view its resolution and filesize here...";
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(imageInfo, "Input Image Information");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImageFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImageFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxProcessed_Click(object sender, EventArgs e)
        {
            SaveImageFile();
        }

        private void modelSelect_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                modelSelect.Text = e.ClickedItem?.Text;
                selectedModel = e.ClickedItem.Text ?? "u2net";
                modelUrl = ModelCatalog.Models[selectedModel];
            }
            catch (NullReferenceException ex)
            {
                lblInfoText.Text = "Unable to select model: " + ex.Message;
            }
        }
    }
}
