namespace ShareX
{
    partial class ImageEditorSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditorSelectorForm));
            btnLegacyImageEditor = new System.Windows.Forms.Button();
            btnModernImageEditor = new System.Windows.Forms.Button();
            lblNote = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnLegacyImageEditor
            // 
            resources.ApplyResources(btnLegacyImageEditor, "btnLegacyImageEditor");
            btnLegacyImageEditor.Name = "btnLegacyImageEditor";
            btnLegacyImageEditor.UseVisualStyleBackColor = true;
            btnLegacyImageEditor.Click += btnLegacyImageEditor_Click;
            // 
            // btnModernImageEditor
            // 
            resources.ApplyResources(btnModernImageEditor, "btnModernImageEditor");
            btnModernImageEditor.Name = "btnModernImageEditor";
            btnModernImageEditor.UseVisualStyleBackColor = true;
            btnModernImageEditor.Click += btnModernImageEditor_Click;
            // 
            // lblNote
            // 
            resources.ApplyResources(lblNote, "lblNote");
            lblNote.Name = "lblNote";
            // 
            // ImageEditorSelectorForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblNote);
            Controls.Add(btnModernImageEditor);
            Controls.Add(btnLegacyImageEditor);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImageEditorSelectorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLegacyImageEditor;
        private System.Windows.Forms.Button btnModernImageEditor;
        private System.Windows.Forms.Label lblNote;
    }
}