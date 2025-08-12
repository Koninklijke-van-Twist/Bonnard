namespace Logistiek_Bonnensorteerder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentDropdown = new System.Windows.Forms.ComboBox();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.orderNumberTextbox = new System.Windows.Forms.TextBox();
            this.orderNumberLabel = new System.Windows.Forms.Label();
            this.pickbonTextbox = new System.Windows.Forms.TextBox();
            this.pickbonLabel = new System.Windows.Forms.Label();
            this.customerNameTextbox = new System.Windows.Forms.TextBox();
            this.transporterTextbox = new System.Windows.Forms.TextBox();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.transporterNameLabel = new System.Windows.Forms.Label();
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
            this.releaseLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(12, 343);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(291, 35);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.departmentDropdown.SelectedIndexChanged += new System.EventHandler(this.departmentDropdown_SelectedIndexChanged);
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(9, 158);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(45, 13);
            this.departmentLabel.TabIndex = 4;
            this.departmentLabel.Text = "Afdeling";
            // 
            // orderNumberTextbox
            // 
            this.orderNumberTextbox.Location = new System.Drawing.Point(122, 182);
            this.orderNumberTextbox.Name = "orderNumberTextbox";
            this.orderNumberTextbox.Size = new System.Drawing.Size(181, 20);
            this.orderNumberTextbox.TabIndex = 5;
            // 
            // orderNumberLabel
            // 
            this.orderNumberLabel.AutoSize = true;
            this.orderNumberLabel.Location = new System.Drawing.Point(9, 185);
            this.orderNumberLabel.Name = "orderNumberLabel";
            this.orderNumberLabel.Size = new System.Drawing.Size(70, 13);
            this.orderNumberLabel.TabIndex = 6;
            this.orderNumberLabel.Text = "Ordernummer";
            // 
            // pickbonTextbox
            // 
            this.pickbonTextbox.Location = new System.Drawing.Point(122, 208);
            this.pickbonTextbox.Name = "pickbonTextbox";
            this.pickbonTextbox.Size = new System.Drawing.Size(181, 20);
            this.pickbonTextbox.TabIndex = 7;
            // 
            // pickbonLabel
            // 
            this.pickbonLabel.AutoSize = true;
            this.pickbonLabel.Location = new System.Drawing.Point(9, 211);
            this.pickbonLabel.Name = "pickbonLabel";
            this.pickbonLabel.Size = new System.Drawing.Size(88, 13);
            this.pickbonLabel.TabIndex = 8;
            this.pickbonLabel.Text = "Pickbon Nummer";
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
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(9, 237);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(57, 13);
            this.customerNameLabel.TabIndex = 11;
            this.customerNameLabel.Text = "Klantnaam";
            // 
            // transporterNameLabel
            // 
            this.transporterNameLabel.AutoSize = true;
            this.transporterNameLabel.Location = new System.Drawing.Point(9, 263);
            this.transporterNameLabel.Name = "transporterNameLabel";
            this.transporterNameLabel.Size = new System.Drawing.Size(67, 13);
            this.transporterNameLabel.TabIndex = 12;
            this.transporterNameLabel.Text = "Transporteur";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.documentTypeDropdown.SelectedIndexChanged += new System.EventHandler(this.documentTypeDropdown_SelectedIndexChanged);
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
            this.pdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer.Location = new System.Drawing.Point(312, 12);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.ShowBookmarks = false;
            this.pdfViewer.ShowToolbar = false;
            this.pdfViewer.Size = new System.Drawing.Size(254, 406);
            this.pdfViewer.TabIndex = 17;
            this.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // cancelAndRestartButton
            // 
            this.cancelAndRestartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelAndRestartButton.Location = new System.Drawing.Point(12, 384);
            this.cancelAndRestartButton.Name = "cancelAndRestartButton";
            this.cancelAndRestartButton.Size = new System.Drawing.Size(263, 23);
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
            this.panel1.Size = new System.Drawing.Size(255, 406);
            this.panel1.TabIndex = 20;
            // 
            // editConfigButton
            // 
            this.editConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editConfigButton.Location = new System.Drawing.Point(279, 384);
            this.editConfigButton.Name = "editConfigButton";
            this.editConfigButton.Size = new System.Drawing.Size(24, 23);
            this.editConfigButton.TabIndex = 21;
            this.editConfigButton.Text = "⚙";
            this.editConfigButton.UseVisualStyleBackColor = true;
            this.editConfigButton.Click += new System.EventHandler(this.editConfigButton_Click);
            // 
            // releaseLabel
            // 
            this.releaseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.releaseLabel.AutoSize = true;
            this.releaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.releaseLabel.Location = new System.Drawing.Point(12, 410);
            this.releaseLabel.Name = "releaseLabel";
            this.releaseLabel.Size = new System.Drawing.Size(98, 13);
            this.releaseLabel.TabIndex = 22;
            this.releaseLabel.Text = "onbekende release";
            this.toolTip1.SetToolTip(this.releaseLabel, "Klik om online de releases in te zien");
            this.releaseLabel.Click += new System.EventHandler(this.releaseLabel_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 430);
            this.Controls.Add(this.releaseLabel);
            this.Controls.Add(this.editConfigButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cancelAndRestartButton);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.selectedDocumentPathLabel);
            this.Controls.Add(this.fileSelectorButton);
            this.Controls.Add(this.documentTypeDropdown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.transporterNameLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.transporterTextbox);
            this.Controls.Add(this.customerNameTextbox);
            this.Controls.Add(this.pickbonLabel);
            this.Controls.Add(this.pickbonTextbox);
            this.Controls.Add(this.orderNumberLabel);
            this.Controls.Add(this.orderNumberTextbox);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.departmentDropdown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(595, 469);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bonnard";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox departmentDropdown;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.TextBox orderNumberTextbox;
        private System.Windows.Forms.Label orderNumberLabel;
        private System.Windows.Forms.TextBox pickbonTextbox;
        private System.Windows.Forms.Label pickbonLabel;
        private System.Windows.Forms.TextBox customerNameTextbox;
        private System.Windows.Forms.TextBox transporterTextbox;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label transporterNameLabel;
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
        private System.Windows.Forms.Label releaseLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

