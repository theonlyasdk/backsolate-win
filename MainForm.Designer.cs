namespace Backsolate
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnRemoveBackground = new Button();
            saveFileDialog = new SaveFileDialog();
            splitContainer1 = new SplitContainer();
            pictureBoxOriginal = new PictureBox();
            label2 = new Label();
            pictureBoxProcessed = new PictureBox();
            label3 = new Label();
            progressBar = new ProgressBar();
            statusBar = new StatusStrip();
            lblInfoText = new ToolStripStatusLabel();
            modelSelect = new ToolStripDropDownButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).BeginInit();
            statusBar.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRemoveBackground
            // 
            btnRemoveBackground.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveBackground.Location = new Point(510, 406);
            btnRemoveBackground.Name = "btnRemoveBackground";
            btnRemoveBackground.Size = new Size(125, 23);
            btnRemoveBackground.TabIndex = 1;
            btnRemoveBackground.Text = "Remove Background";
            btnRemoveBackground.UseVisualStyleBackColor = true;
            btnRemoveBackground.Click += btnRemoveBackground_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 30);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(pictureBoxOriginal);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(pictureBoxProcessed);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Size = new Size(624, 370);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.TabIndex = 2;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxOriginal.BackColor = SystemColors.ButtonHighlight;
            pictureBoxOriginal.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxOriginal.Location = new Point(0, 0);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(297, 352);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 0;
            pictureBoxOriginal.TabStop = false;
            toolTip1.SetToolTip(pictureBoxOriginal, "Click to select an image to remove the background of...");
            pictureBoxOriginal.Click += pictureBoxOriginal_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Location = new Point(0, 355);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 0;
            label2.Text = "Original image:";
            // 
            // pictureBoxProcessed
            // 
            pictureBoxProcessed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxProcessed.BackColor = SystemColors.ButtonHighlight;
            pictureBoxProcessed.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxProcessed.Location = new Point(0, 0);
            pictureBoxProcessed.Name = "pictureBoxProcessed";
            pictureBoxProcessed.Size = new Size(318, 352);
            pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProcessed.TabIndex = 0;
            pictureBoxProcessed.TabStop = false;
            toolTip1.SetToolTip(pictureBoxProcessed, "Click to save the resultant image...");
            pictureBoxProcessed.Click += pictureBoxProcessed_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(0, 355);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 0;
            label3.Text = "Removed background:";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 406);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(492, 23);
            progressBar.TabIndex = 3;
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new ToolStripItem[] { lblInfoText, modelSelect });
            statusBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusBar.Location = new Point(0, 432);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(648, 22);
            statusBar.TabIndex = 4;
            statusBar.Text = "statusStrip1";
            // 
            // lblInfoText
            // 
            lblInfoText.Name = "lblInfoText";
            lblInfoText.Size = new Size(232, 17);
            lblInfoText.Text = "Click on the first box to choose an image...";
            // 
            // modelSelect
            // 
            modelSelect.Alignment = ToolStripItemAlignment.Right;
            modelSelect.DisplayStyle = ToolStripItemDisplayStyle.Text;
            modelSelect.Image = (Image)resources.GetObject("modelSelect.Image");
            modelSelect.ImageTransparentColor = Color.Magenta;
            modelSelect.Name = "modelSelect";
            modelSelect.Size = new Size(188, 20);
            modelSelect.Text = "Select a model... (Default u2net)";
            modelSelect.DropDownItemClicked += modelSelect_DropDownItemClicked;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(648, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(163, 22);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(163, 22);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(160, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(163, 22);
            saveToolStripMenuItem.Text = "&Save As...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(163, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(52, 20);
            toolsToolStripMenuItem.Text = "&Image";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(131, 22);
            customizeToolStripMenuItem.Text = "&Image Info";
            customizeToolStripMenuItem.Click += customizeToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 454);
            Controls.Add(statusBar);
            Controls.Add(menuStrip1);
            Controls.Add(progressBar);
            Controls.Add(splitContainer1);
            Controls.Add(btnRemoveBackground);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Backsolate";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).EndInit();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRemoveBackground;
        private SaveFileDialog saveFileDialog;
        private SplitContainer splitContainer1;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxProcessed;
        private Label label2;
        private Label label3;
        private ProgressBar progressBar;
        private StatusStrip statusBar;
        private ToolStripStatusLabel lblInfoText;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripDropDownButton modelSelect;
        private ToolTip toolTip1;
    }
}
