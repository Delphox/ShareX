namespace ShareX.HelpersLib
{
    partial class HashCheckerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HashCheckerForm));
            txtFilePath = new System.Windows.Forms.TextBox();
            btnFilePathBrowse = new System.Windows.Forms.Button();
            lblHashType = new System.Windows.Forms.Label();
            lblResult = new System.Windows.Forms.Label();
            lblTarget = new System.Windows.Forms.Label();
            btnStartHashCheck = new System.Windows.Forms.Button();
            cbHashType = new System.Windows.Forms.ComboBox();
            txtResult = new System.Windows.Forms.TextBox();
            txtTarget = new System.Windows.Forms.TextBox();
            lblFilePath = new System.Windows.Forms.Label();
            lblFilePath2 = new System.Windows.Forms.Label();
            txtFilePath2 = new System.Windows.Forms.TextBox();
            btnFilePathBrowse2 = new System.Windows.Forms.Button();
            cbCompareTwoFiles = new System.Windows.Forms.CheckBox();
            pbProgress = new BlackStyleProgressBar();
            pbTick = new System.Windows.Forms.PictureBox();
            pbCross = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbTick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCross).BeginInit();
            SuspendLayout();
            // 
            // txtFilePath
            // 
            txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(txtFilePath, "txtFilePath");
            txtFilePath.Name = "txtFilePath";
            txtFilePath.TextChanged += txtFilePath_TextChanged;
            // 
            // btnFilePathBrowse
            // 
            resources.ApplyResources(btnFilePathBrowse, "btnFilePathBrowse");
            btnFilePathBrowse.Name = "btnFilePathBrowse";
            btnFilePathBrowse.UseVisualStyleBackColor = true;
            btnFilePathBrowse.Click += btnFilePathBrowse_Click;
            // 
            // lblHashType
            // 
            resources.ApplyResources(lblHashType, "lblHashType");
            lblHashType.Name = "lblHashType";
            // 
            // lblResult
            // 
            resources.ApplyResources(lblResult, "lblResult");
            lblResult.Name = "lblResult";
            // 
            // lblTarget
            // 
            resources.ApplyResources(lblTarget, "lblTarget");
            lblTarget.Name = "lblTarget";
            // 
            // btnStartHashCheck
            // 
            resources.ApplyResources(btnStartHashCheck, "btnStartHashCheck");
            btnStartHashCheck.Name = "btnStartHashCheck";
            btnStartHashCheck.UseVisualStyleBackColor = true;
            btnStartHashCheck.Click += btnStartHashCheck_Click;
            // 
            // cbHashType
            // 
            cbHashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbHashType.FormattingEnabled = true;
            resources.ApplyResources(cbHashType, "cbHashType");
            cbHashType.Name = "cbHashType";
            // 
            // txtResult
            // 
            txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(txtResult, "txtResult");
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.TextChanged += txtResult_TextChanged;
            // 
            // txtTarget
            // 
            txtTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(txtTarget, "txtTarget");
            txtTarget.Name = "txtTarget";
            txtTarget.TextChanged += txtTarget_TextChanged;
            // 
            // lblFilePath
            // 
            resources.ApplyResources(lblFilePath, "lblFilePath");
            lblFilePath.Name = "lblFilePath";
            // 
            // lblFilePath2
            // 
            resources.ApplyResources(lblFilePath2, "lblFilePath2");
            lblFilePath2.Name = "lblFilePath2";
            // 
            // txtFilePath2
            // 
            txtFilePath2.AllowDrop = true;
            txtFilePath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(txtFilePath2, "txtFilePath2");
            txtFilePath2.Name = "txtFilePath2";
            txtFilePath2.TextChanged += txtFilePath2_TextChanged;
            txtFilePath2.DragDrop += txtFilePath2_DragDrop;
            txtFilePath2.DragEnter += txtFilePath2_DragEnter;
            // 
            // btnFilePathBrowse2
            // 
            resources.ApplyResources(btnFilePathBrowse2, "btnFilePathBrowse2");
            btnFilePathBrowse2.Name = "btnFilePathBrowse2";
            btnFilePathBrowse2.UseVisualStyleBackColor = true;
            btnFilePathBrowse2.Click += btnFilePathBrowse2_Click;
            // 
            // cbCompareTwoFiles
            // 
            resources.ApplyResources(cbCompareTwoFiles, "cbCompareTwoFiles");
            cbCompareTwoFiles.Name = "cbCompareTwoFiles";
            cbCompareTwoFiles.UseVisualStyleBackColor = true;
            cbCompareTwoFiles.CheckedChanged += cbCompareTwoFiles_CheckedChanged;
            // 
            // pbProgress
            // 
            resources.ApplyResources(pbProgress, "pbProgress");
            pbProgress.Name = "pbProgress";
            pbProgress.ShowPercentageText = true;
            // 
            // pbTick
            // 
            pbTick.Image = Properties.Resources.tick_circle;
            resources.ApplyResources(pbTick, "pbTick");
            pbTick.Name = "pbTick";
            pbTick.TabStop = false;
            // 
            // pbCross
            // 
            pbCross.Image = Properties.Resources.cross_circle;
            resources.ApplyResources(pbCross, "pbCross");
            pbCross.Name = "pbCross";
            pbCross.TabStop = false;
            // 
            // HashCheckerForm
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(pbTick);
            Controls.Add(pbCross);
            Controls.Add(pbProgress);
            Controls.Add(lblFilePath2);
            Controls.Add(txtFilePath2);
            Controls.Add(txtFilePath);
            Controls.Add(btnFilePathBrowse2);
            Controls.Add(cbCompareTwoFiles);
            Controls.Add(lblTarget);
            Controls.Add(lblFilePath);
            Controls.Add(btnStartHashCheck);
            Controls.Add(lblResult);
            Controls.Add(txtTarget);
            Controls.Add(cbHashType);
            Controls.Add(btnFilePathBrowse);
            Controls.Add(txtResult);
            Controls.Add(lblHashType);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HashCheckerForm";
            Shown += HashCheckerForm_Shown;
            DragDrop += HashCheckerForm_DragDrop;
            DragEnter += HashCheckerForm_DragEnter;
            ((System.ComponentModel.ISupportInitialize)pbTick).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCross).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnFilePathBrowse;
        private System.Windows.Forms.Label lblHashType;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Button btnStartHashCheck;
        private System.Windows.Forms.ComboBox cbHashType;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblFilePath2;
        private System.Windows.Forms.TextBox txtFilePath2;
        private System.Windows.Forms.Button btnFilePathBrowse2;
        private System.Windows.Forms.CheckBox cbCompareTwoFiles;
        private BlackStyleProgressBar pbProgress;
        private System.Windows.Forms.PictureBox pbTick;
        private System.Windows.Forms.PictureBox pbCross;
    }
}