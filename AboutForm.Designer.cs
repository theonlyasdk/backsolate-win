namespace Backsolate
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            lblTitle = new Label();
            btnClose = new Button();
            lblAuthor = new Label();
            creditsBox = new RichTextBox();
            lblGitHubLink = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(402, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Backsolate";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(336, 289);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(57, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblAuthor
            // 
            lblAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAuthor.Location = new Point(0, 62);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(402, 22);
            lblAuthor.TabIndex = 0;
            lblAuthor.Text = "By TheOnlyASDK";
            lblAuthor.TextAlign = ContentAlignment.TopCenter;
            // 
            // creditsBox
            // 
            creditsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            creditsBox.BorderStyle = BorderStyle.FixedSingle;
            creditsBox.Location = new Point(11, 84);
            creditsBox.Name = "creditsBox";
            creditsBox.ReadOnly = true;
            creditsBox.Size = new Size(379, 198);
            creditsBox.TabIndex = 2;
            creditsBox.Text = resources.GetString("creditsBox.Text");
            // 
            // lblGitHubLink
            // 
            lblGitHubLink.AutoSize = true;
            lblGitHubLink.LinkBehavior = LinkBehavior.HoverUnderline;
            lblGitHubLink.Location = new Point(12, 292);
            lblGitHubLink.Name = "lblGitHubLink";
            lblGitHubLink.Size = new Size(45, 15);
            lblGitHubLink.TabIndex = 3;
            lblGitHubLink.TabStop = true;
            lblGitHubLink.Text = "GitHub";
            lblGitHubLink.LinkClicked += lblGitHubLink_LinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 318);
            ControlBox = false;
            Controls.Add(lblGitHubLink);
            Controls.Add(creditsBox);
            Controls.Add(btnClose);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            Text = "About...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnClose;
        private Label lblAuthor;
        private RichTextBox creditsBox;
        private LinkLabel lblGitHubLink;
    }
}