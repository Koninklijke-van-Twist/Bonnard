﻿namespace Logistiek_Bonnensorteerder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentDropdown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.orderNumberTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pickbonTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customerNameTextbox = new System.Windows.Forms.TextBox();
            this.transporterTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.documentTypeDropdown = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSelectorButton = new System.Windows.Forms.Button();
            this.selectedDocumentPathLabel = new System.Windows.Forms.Label();
            this.pdfViewer = new PdfiumViewer.PdfViewer();
            this.cancelAndRestartButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editConfigButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(12, 343);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(555, 50);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(122, 129);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum Bon";
            // 
            // departmentDropdown
            // 
            this.departmentDropdown.FormattingEnabled = true;
            this.departmentDropdown.Location = new System.Drawing.Point(122, 155);
            this.departmentDropdown.Name = "departmentDropdown";
            this.departmentDropdown.Size = new System.Drawing.Size(181, 21);
            this.departmentDropdown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Afdeling";
            // 
            // orderNumberTextbox
            // 
            this.orderNumberTextbox.Location = new System.Drawing.Point(122, 182);
            this.orderNumberTextbox.Name = "orderNumberTextbox";
            this.orderNumberTextbox.Size = new System.Drawing.Size(181, 20);
            this.orderNumberTextbox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Termijnorder Nummer";
            // 
            // pickbonTextbox
            // 
            this.pickbonTextbox.Location = new System.Drawing.Point(122, 208);
            this.pickbonTextbox.Name = "pickbonTextbox";
            this.pickbonTextbox.Size = new System.Drawing.Size(181, 20);
            this.pickbonTextbox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pickbon Nummer";
            // 
            // customerNameTextbox
            // 
            this.customerNameTextbox.Location = new System.Drawing.Point(122, 234);
            this.customerNameTextbox.Name = "customerNameTextbox";
            this.customerNameTextbox.Size = new System.Drawing.Size(181, 20);
            this.customerNameTextbox.TabIndex = 9;
            // 
            // transporterTextbox
            // 
            this.transporterTextbox.Location = new System.Drawing.Point(122, 260);
            this.transporterTextbox.Name = "transporterTextbox";
            this.transporterTextbox.Size = new System.Drawing.Size(181, 20);
            this.transporterTextbox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Klantnaam";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Transporteur";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Documenttype";
            // 
            // documentTypeDropdown
            // 
            this.documentTypeDropdown.FormattingEnabled = true;
            this.documentTypeDropdown.Location = new System.Drawing.Point(122, 287);
            this.documentTypeDropdown.Name = "documentTypeDropdown";
            this.documentTypeDropdown.Size = new System.Drawing.Size(181, 21);
            this.documentTypeDropdown.TabIndex = 14;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // fileSelectorButton
            // 
            this.fileSelectorButton.Location = new System.Drawing.Point(12, 314);
            this.fileSelectorButton.Name = "fileSelectorButton";
            this.fileSelectorButton.Size = new System.Drawing.Size(104, 23);
            this.fileSelectorButton.TabIndex = 15;
            this.fileSelectorButton.Text = "Kies Document";
            this.fileSelectorButton.UseVisualStyleBackColor = true;
            this.fileSelectorButton.Click += new System.EventHandler(this.fileSelectorButton_Click);
            // 
            // selectedDocumentPathLabel
            // 
            this.selectedDocumentPathLabel.Location = new System.Drawing.Point(122, 319);
            this.selectedDocumentPathLabel.Name = "selectedDocumentPathLabel";
            this.selectedDocumentPathLabel.Size = new System.Drawing.Size(181, 13);
            this.selectedDocumentPathLabel.TabIndex = 16;
            this.selectedDocumentPathLabel.Text = "Selecteer een document";
            // 
            // pdfViewer
            // 
            this.pdfViewer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer.Location = new System.Drawing.Point(312, 12);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.ShowBookmarks = false;
            this.pdfViewer.ShowToolbar = false;
            this.pdfViewer.Size = new System.Drawing.Size(254, 325);
            this.pdfViewer.TabIndex = 17;
            this.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // cancelAndRestartButton
            // 
            this.cancelAndRestartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelAndRestartButton.Location = new System.Drawing.Point(12, 395);
            this.cancelAndRestartButton.Name = "cancelAndRestartButton";
            this.cancelAndRestartButton.Size = new System.Drawing.Size(525, 23);
            this.cancelAndRestartButton.TabIndex = 18;
            this.cancelAndRestartButton.Text = "Annuleren en opnieuw beginnen";
            this.cancelAndRestartButton.UseVisualStyleBackColor = true;
            this.cancelAndRestartButton.Click += new System.EventHandler(this.cancelAndRestartButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Logistiek_Bonnensorteerder.Properties.Resources.logo_website_2_3;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(312, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 325);
            this.panel1.TabIndex = 20;
            // 
            // editConfigButton
            // 
            this.editConfigButton.Location = new System.Drawing.Point(543, 395);
            this.editConfigButton.Name = "editConfigButton";
            this.editConfigButton.Size = new System.Drawing.Size(24, 23);
            this.editConfigButton.TabIndex = 21;
            this.editConfigButton.Text = "⚙";
            this.editConfigButton.UseVisualStyleBackColor = true;
            this.editConfigButton.Click += new System.EventHandler(this.editConfigButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 430);
            this.Controls.Add(this.editConfigButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cancelAndRestartButton);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.selectedDocumentPathLabel);
            this.Controls.Add(this.fileSelectorButton);
            this.Controls.Add(this.documentTypeDropdown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.transporterTextbox);
            this.Controls.Add(this.customerNameTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pickbonTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.orderNumberTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.departmentDropdown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bonnard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox departmentDropdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox orderNumberTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pickbonTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox customerNameTextbox;
        private System.Windows.Forms.TextBox transporterTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox documentTypeDropdown;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button fileSelectorButton;
        private System.Windows.Forms.Label selectedDocumentPathLabel;
        private PdfiumViewer.PdfViewer pdfViewer;
        private System.Windows.Forms.Button cancelAndRestartButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button editConfigButton;
    }
}

