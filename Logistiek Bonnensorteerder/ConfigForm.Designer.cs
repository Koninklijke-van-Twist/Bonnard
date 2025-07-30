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
            this.departmentsConfigInput = new System.Windows.Forms.TextBox();
            this.departmentsConfigLabel = new System.Windows.Forms.Label();
            this.documentTypesConfigInput = new System.Windows.Forms.TextBox();
            this.documentTypesConfigLabel = new System.Windows.Forms.Label();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.rootFolderTextfield = new System.Windows.Forms.TextBox();
            this.saveOriginalFileCheckbox = new System.Windows.Forms.CheckBox();
            this.departmentListLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // departmentsConfigInput
            // 
            this.departmentsConfigInput.Location = new System.Drawing.Point(12, 40);
            this.departmentsConfigInput.Multiline = true;
            this.departmentsConfigInput.Name = "departmentsConfigInput";
            this.departmentsConfigInput.Size = new System.Drawing.Size(153, 398);
            this.departmentsConfigInput.TabIndex = 0;
            this.departmentsConfigInput.TextChanged += new System.EventHandler(this.departmentsConfigInput_TextChanged);
            // 
            // departmentsConfigLabel
            // 
            this.departmentsConfigLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.departmentsConfigLabel.Location = new System.Drawing.Point(171, 40);
            this.departmentsConfigLabel.Name = "departmentsConfigLabel";
            this.departmentsConfigLabel.Size = new System.Drawing.Size(145, 398);
            this.departmentsConfigLabel.TabIndex = 1;
            this.departmentsConfigLabel.Text = "Departments";
            // 
            // documentTypesConfigInput
            // 
            this.documentTypesConfigInput.Location = new System.Drawing.Point(322, 40);
            this.documentTypesConfigInput.Multiline = true;
            this.documentTypesConfigInput.Name = "documentTypesConfigInput";
            this.documentTypesConfigInput.Size = new System.Drawing.Size(153, 398);
            this.documentTypesConfigInput.TabIndex = 2;
            this.documentTypesConfigInput.TextChanged += new System.EventHandler(this.departmentsConfigInput_TextChanged);
            // 
            // documentTypesConfigLabel
            // 
            this.documentTypesConfigLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentTypesConfigLabel.Location = new System.Drawing.Point(481, 40);
            this.documentTypesConfigLabel.Name = "documentTypesConfigLabel";
            this.documentTypesConfigLabel.Size = new System.Drawing.Size(145, 398);
            this.documentTypesConfigLabel.TabIndex = 3;
            this.documentTypesConfigLabel.Text = "Document Types";
            this.documentTypesConfigLabel.Click += new System.EventHandler(this.documentTypesConfigLabel_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(509, 441);
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
            this.rootFolderTextfield.Size = new System.Drawing.Size(491, 20);
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
            // departmentListLabel
            // 
            this.departmentListLabel.AutoSize = true;
            this.departmentListLabel.Location = new System.Drawing.Point(12, 24);
            this.departmentListLabel.Name = "departmentListLabel";
            this.departmentListLabel.Size = new System.Drawing.Size(128, 13);
            this.departmentListLabel.TabIndex = 7;
            this.departmentListLabel.Text = "Afdelingen (één per regel)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Documenttypes (één per regel)";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 490);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.departmentListLabel);
            this.Controls.Add(this.saveOriginalFileCheckbox);
            this.Controls.Add(this.rootFolderTextfield);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.documentTypesConfigLabel);
            this.Controls.Add(this.documentTypesConfigInput);
            this.Controls.Add(this.departmentsConfigLabel);
            this.Controls.Add(this.departmentsConfigInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox departmentsConfigInput;
        private System.Windows.Forms.Label departmentsConfigLabel;
        private System.Windows.Forms.TextBox documentTypesConfigInput;
        private System.Windows.Forms.Label documentTypesConfigLabel;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.TextBox rootFolderTextfield;
        private System.Windows.Forms.CheckBox saveOriginalFileCheckbox;
        private System.Windows.Forms.Label departmentListLabel;
        private System.Windows.Forms.Label label1;
    }
}