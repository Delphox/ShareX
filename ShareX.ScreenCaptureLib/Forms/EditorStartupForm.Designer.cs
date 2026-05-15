namespace ShareX.ScreenCaptureLib
{
    partial class EditorStartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorStartupForm));
            btnOpenImageFile = new System.Windows.Forms.Button();
            btnCreateNewImage = new System.Windows.Forms.Button();
            btnLoadImageFromClipboard = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnLoadImageFromURL = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnOpenImageFile
            // 
            resources.ApplyResources(btnOpenImageFile, "btnOpenImageFile");
            btnOpenImageFile.Image = Properties.Resources.folder_open_image;
            btnOpenImageFile.Name = "btnOpenImageFile";
            btnOpenImageFile.UseVisualStyleBackColor = true;
            btnOpenImageFile.Click += btnOpenImageFile_Click;
            // 
            // btnCreateNewImage
            // 
            resources.ApplyResources(btnCreateNewImage, "btnCreateNewImage");
            btnCreateNewImage.Image = Properties.Resources.image_empty;
            btnCreateNewImage.Name = "btnCreateNewImage";
            btnCreateNewImage.UseVisualStyleBackColor = true;
            btnCreateNewImage.Click += btnCreateNewImage_Click;
            // 
            // btnLoadImageFromClipboard
            // 
            resources.ApplyResources(btnLoadImageFromClipboard, "btnLoadImageFromClipboard");
            btnLoadImageFromClipboard.Image = Properties.Resources.clipboard;
            btnLoadImageFromClipboard.Name = "btnLoadImageFromClipboard";
            btnLoadImageFromClipboard.UseVisualStyleBackColor = true;
            btnLoadImageFromClipboard.Click += btnLoadImageFromClipboard_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.cross;
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLoadImageFromURL
            // 
            resources.ApplyResources(btnLoadImageFromURL, "btnLoadImageFromURL");
            btnLoadImageFromURL.Image = Properties.Resources.drive_globe;
            btnLoadImageFromURL.Name = "btnLoadImageFromURL";
            btnLoadImageFromURL.UseVisualStyleBackColor = true;
            btnLoadImageFromURL.Click += btnLoadImageFromURL_Click;
            // 
            // EditorStartupForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(btnLoadImageFromURL);
            Controls.Add(btnCancel);
            Controls.Add(btnLoadImageFromClipboard);
            Controls.Add(btnCreateNewImage);
            Controls.Add(btnOpenImageFile);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditorStartupForm";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenImageFile;
        private System.Windows.Forms.Button btnCreateNewImage;
        private System.Windows.Forms.Button btnLoadImageFromClipboard;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoadImageFromURL;
    }
}