namespace EXIFHelper
{
    partial class frmMain
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnCheckDate = new System.Windows.Forms.Button();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.btnWriteDate = new System.Windows.Forms.Button();
            this.lblDateTimeFormat = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.btnWriteGeoTag = new System.Windows.Forms.Button();
            this.lstFilledFiles = new System.Windows.Forms.ListBox();
            this.btnRemoveFiles = new System.Windows.Forms.Button();
            this.webGeocode = new System.Windows.Forms.WebBrowser();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnCheckGeotag = new System.Windows.Forms.Button();
            this.lblFilesCount = new System.Windows.Forms.Label();
            this.btnRemoveFilesWithDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(28, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(80, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select File(s)";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 101);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(525, 446);
            this.lstFiles.TabIndex = 1;
            // 
            // btnCheckDate
            // 
            this.btnCheckDate.Location = new System.Drawing.Point(28, 40);
            this.btnCheckDate.Name = "btnCheckDate";
            this.btnCheckDate.Size = new System.Drawing.Size(78, 23);
            this.btnCheckDate.TabIndex = 2;
            this.btnCheckDate.Text = "Check Date";
            this.btnCheckDate.UseVisualStyleBackColor = true;
            this.btnCheckDate.Click += new System.EventHandler(this.btnCheckDate_Click);
            // 
            // txtDateTime
            // 
            this.txtDateTime.Location = new System.Drawing.Point(932, 68);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(228, 20);
            this.txtDateTime.TabIndex = 3;
            // 
            // btnWriteDate
            // 
            this.btnWriteDate.Enabled = false;
            this.btnWriteDate.Location = new System.Drawing.Point(1182, 68);
            this.btnWriteDate.Name = "btnWriteDate";
            this.btnWriteDate.Size = new System.Drawing.Size(92, 23);
            this.btnWriteDate.TabIndex = 4;
            this.btnWriteDate.Text = "Write Date";
            this.btnWriteDate.UseVisualStyleBackColor = true;
            this.btnWriteDate.Click += new System.EventHandler(this.btnWriteDate_Click);
            // 
            // lblDateTimeFormat
            // 
            this.lblDateTimeFormat.AutoSize = true;
            this.lblDateTimeFormat.Location = new System.Drawing.Point(932, 95);
            this.lblDateTimeFormat.Name = "lblDateTimeFormat";
            this.lblDateTimeFormat.Size = new System.Drawing.Size(114, 13);
            this.lblDateTimeFormat.TabIndex = 5;
            this.lblDateTimeFormat.Text = "yyyy:MM:dd HH:mm:ss";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(943, 435);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(45, 13);
            this.lblLatitude.TabIndex = 6;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(943, 476);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(54, 13);
            this.lblLongitude.TabIndex = 7;
            this.lblLongitude.Text = "Longitude";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(946, 452);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 20);
            this.txtLatitude.TabIndex = 8;
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(946, 493);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(100, 20);
            this.txtLongitude.TabIndex = 9;
            // 
            // btnWriteGeoTag
            // 
            this.btnWriteGeoTag.Enabled = false;
            this.btnWriteGeoTag.Location = new System.Drawing.Point(1103, 490);
            this.btnWriteGeoTag.Name = "btnWriteGeoTag";
            this.btnWriteGeoTag.Size = new System.Drawing.Size(92, 23);
            this.btnWriteGeoTag.TabIndex = 11;
            this.btnWriteGeoTag.Text = "Write GeoTag";
            this.btnWriteGeoTag.UseVisualStyleBackColor = true;
            this.btnWriteGeoTag.Click += new System.EventHandler(this.btnWriteGeoTag_Click);
            // 
            // lstFilledFiles
            // 
            this.lstFilledFiles.FormattingEnabled = true;
            this.lstFilledFiles.HorizontalScrollbar = true;
            this.lstFilledFiles.Location = new System.Drawing.Point(543, 101);
            this.lstFilledFiles.Name = "lstFilledFiles";
            this.lstFilledFiles.Size = new System.Drawing.Size(373, 446);
            this.lstFilledFiles.TabIndex = 12;
            this.lstFilledFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFilledFiles_KeyDown);
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Location = new System.Drawing.Point(72, 69);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(134, 23);
            this.btnRemoveFiles.TabIndex = 13;
            this.btnRemoveFiles.Text = "Remove Selectred Files";
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // webGeocode
            // 
            this.webGeocode.Location = new System.Drawing.Point(932, 135);
            this.webGeocode.MinimumSize = new System.Drawing.Size(20, 20);
            this.webGeocode.Name = "webGeocode";
            this.webGeocode.Size = new System.Drawing.Size(342, 250);
            this.webGeocode.TabIndex = 14;
            this.webGeocode.Url = new System.Uri("", System.UriKind.Relative);
            this.webGeocode.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webGeocode_DocumentCompleted);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(25, 74);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 15;
            this.lblSource.Text = "Source";
            // 
            // btnCheckGeotag
            // 
            this.btnCheckGeotag.Location = new System.Drawing.Point(112, 40);
            this.btnCheckGeotag.Name = "btnCheckGeotag";
            this.btnCheckGeotag.Size = new System.Drawing.Size(94, 23);
            this.btnCheckGeotag.TabIndex = 16;
            this.btnCheckGeotag.Text = "Check Geotag";
            this.btnCheckGeotag.UseVisualStyleBackColor = true;
            this.btnCheckGeotag.Click += new System.EventHandler(this.btnCheckGeotag_Click);
            // 
            // lblFilesCount
            // 
            this.lblFilesCount.AutoSize = true;
            this.lblFilesCount.Location = new System.Drawing.Point(12, 554);
            this.lblFilesCount.Name = "lblFilesCount";
            this.lblFilesCount.Size = new System.Drawing.Size(72, 13);
            this.lblFilesCount.TabIndex = 17;
            this.lblFilesCount.Text = "0 file selected";
            // 
            // btnRemoveFilesWithDate
            // 
            this.btnRemoveFilesWithDate.Location = new System.Drawing.Point(631, 12);
            this.btnRemoveFilesWithDate.Name = "btnRemoveFilesWithDate";
            this.btnRemoveFilesWithDate.Size = new System.Drawing.Size(230, 23);
            this.btnRemoveFilesWithDate.TabIndex = 18;
            this.btnRemoveFilesWithDate.Text = "Remove Files With Date";
            this.btnRemoveFilesWithDate.UseVisualStyleBackColor = true;
            this.btnRemoveFilesWithDate.Click += new System.EventHandler(this.btnRemoveFilesWithDate_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 601);
            this.Controls.Add(this.btnRemoveFilesWithDate);
            this.Controls.Add(this.lblFilesCount);
            this.Controls.Add(this.btnCheckGeotag);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.webGeocode);
            this.Controls.Add(this.btnRemoveFiles);
            this.Controls.Add(this.lstFilledFiles);
            this.Controls.Add(this.btnWriteGeoTag);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblDateTimeFormat);
            this.Controls.Add(this.btnWriteDate);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.btnCheckDate);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnSelect);
            this.Name = "frmMain";
            this.Text = "EXIF Helper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnCheckDate;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Button btnWriteDate;
        private System.Windows.Forms.Label lblDateTimeFormat;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Button btnWriteGeoTag;
        private System.Windows.Forms.ListBox lstFilledFiles;
        private System.Windows.Forms.Button btnRemoveFiles;
        private System.Windows.Forms.WebBrowser webGeocode;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button btnCheckGeotag;
        private System.Windows.Forms.Label lblFilesCount;
        private System.Windows.Forms.Button btnRemoveFilesWithDate;
    }
}

