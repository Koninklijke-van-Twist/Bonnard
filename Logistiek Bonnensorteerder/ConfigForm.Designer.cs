namespace Logistiek_Bonnensorteerder
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.rootFolderTextfield = new System.Windows.Forms.TextBox();
            this.saveOriginalFileCheckbox = new System.Windows.Forms.CheckBox();
            this.documentTypesBox = new System.Windows.Forms.GroupBox();
            this.departmentsBox = new System.Windows.Forms.GroupBox();
            this.departmentsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.documentTypesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addDepartmentButton = new System.Windows.Forms.Button();
            this.addDocumentTypeButton = new System.Windows.Forms.Button();
            this.documentTypesBox.SuspendLayout();
            this.departmentsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(515, 437);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(117, 41);
            this.saveConfigButton.TabIndex = 4;
            this.saveConfigButton.Text = "Configuratie Opslaan";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // rootFolderTextfield
            // 
            this.rootFolderTextfield.Location = new System.Drawing.Point(12, 441);
            this.rootFolderTextfield.Name = "rootFolderTextfield";
            this.rootFolderTextfield.Size = new System.Drawing.Size(497, 20);
            this.rootFolderTextfield.TabIndex = 5;
            this.rootFolderTextfield.Leave += new System.EventHandler(this.rootFolderTextfield_TextChanged);
            // 
            // saveOriginalFileCheckbox
            // 
            this.saveOriginalFileCheckbox.AutoSize = true;
            this.saveOriginalFileCheckbox.Location = new System.Drawing.Point(12, 467);
            this.saveOriginalFileCheckbox.Name = "saveOriginalFileCheckbox";
            this.saveOriginalFileCheckbox.Size = new System.Drawing.Size(191, 17);
            this.saveOriginalFileCheckbox.TabIndex = 6;
            this.saveOriginalFileCheckbox.Text = "Oorspronkelijke bestand behouden";
            this.saveOriginalFileCheckbox.UseVisualStyleBackColor = true;
            this.saveOriginalFileCheckbox.CheckedChanged += new System.EventHandler(this.saveOriginalFileCheckbox_CheckedChanged);
            // 
            // documentTypesBox
            // 
            this.documentTypesBox.Controls.Add(this.addDocumentTypeButton);
            this.documentTypesBox.Controls.Add(this.documentTypesPanel);
            this.documentTypesBox.Location = new System.Drawing.Point(325, 9);
            this.documentTypesBox.Name = "documentTypesBox";
            this.documentTypesBox.Size = new System.Drawing.Size(307, 426);
            this.documentTypesBox.TabIndex = 9;
            this.documentTypesBox.TabStop = false;
            this.documentTypesBox.Text = "Documenttypes";
            // 
            // departmentsBox
            // 
            this.departmentsBox.Controls.Add(this.addDepartmentButton);
            this.departmentsBox.Controls.Add(this.departmentsPanel);
            this.departmentsBox.Location = new System.Drawing.Point(12, 9);
            this.departmentsBox.Name = "departmentsBox";
            this.departmentsBox.Size = new System.Drawing.Size(307, 426);
            this.departmentsBox.TabIndex = 10;
            this.departmentsBox.TabStop = false;
            this.departmentsBox.Text = "Afdelingen";
            // 
            // departmentsPanel
            // 
            this.departmentsPanel.Location = new System.Drawing.Point(6, 19);
            this.departmentsPanel.Name = "departmentsPanel";
            this.departmentsPanel.Size = new System.Drawing.Size(295, 401);
            this.departmentsPanel.TabIndex = 0;
            // 
            // documentTypesPanel
            // 
            this.documentTypesPanel.Location = new System.Drawing.Point(6, 19);
            this.documentTypesPanel.Name = "documentTypesPanel";
            this.documentTypesPanel.Size = new System.Drawing.Size(295, 401);
            this.documentTypesPanel.TabIndex = 1;
            // 
            // addDepartmentButton
            // 
            this.addDepartmentButton.Location = new System.Drawing.Point(281, -1);
            this.addDepartmentButton.Name = "addDepartmentButton";
            this.addDepartmentButton.Size = new System.Drawing.Size(23, 23);
            this.addDepartmentButton.TabIndex = 1;
            this.addDepartmentButton.Text = "✚";
            this.addDepartmentButton.UseVisualStyleBackColor = true;
            this.addDepartmentButton.Click += new System.EventHandler(this.addDepartmentButton_Click);
            // 
            // addDocumentTypeButton
            // 
            this.addDocumentTypeButton.Location = new System.Drawing.Point(283, -1);
            this.addDocumentTypeButton.Name = "addDocumentTypeButton";
            this.addDocumentTypeButton.Size = new System.Drawing.Size(23, 23);
            this.addDocumentTypeButton.TabIndex = 2;
            this.addDocumentTypeButton.Text = "✚";
            this.addDocumentTypeButton.UseVisualStyleBackColor = true;
            this.addDocumentTypeButton.Click += new System.EventHandler(this.addDocumentTypeButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 490);
            this.Controls.Add(this.departmentsBox);
            this.Controls.Add(this.documentTypesBox);
            this.Controls.Add(this.saveOriginalFileCheckbox);
            this.Controls.Add(this.rootFolderTextfield);
            this.Controls.Add(this.saveConfigButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.documentTypesBox.ResumeLayout(false);
            this.departmentsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.TextBox rootFolderTextfield;
        private System.Windows.Forms.CheckBox saveOriginalFileCheckbox;
        private System.Windows.Forms.GroupBox documentTypesBox;
        private System.Windows.Forms.GroupBox departmentsBox;
        private System.Windows.Forms.FlowLayoutPanel documentTypesPanel;
        private System.Windows.Forms.FlowLayoutPanel departmentsPanel;
        private System.Windows.Forms.Button addDocumentTypeButton;
        private System.Windows.Forms.Button addDepartmentButton;
    }
}