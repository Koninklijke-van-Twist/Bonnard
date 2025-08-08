namespace Logistiek_Bonnensorteerder
{
    partial class EditEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEntryForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.dateField = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentCheck = new System.Windows.Forms.CheckBox();
            this.orderNumberCheck = new System.Windows.Forms.CheckBox();
            this.pickbonCheck = new System.Windows.Forms.CheckBox();
            this.customerNameCheck = new System.Windows.Forms.CheckBox();
            this.transporterNameCheck = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.transporterNameAllowedCheck = new System.Windows.Forms.CheckBox();
            this.customerNameAllowedCheck = new System.Windows.Forms.CheckBox();
            this.pickbonAllowedCheck = new System.Windows.Forms.CheckBox();
            this.orderNumberAllowedCheck = new System.Windows.Forms.CheckBox();
            this.departmentAllowedCheck = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(177, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // dateField
            // 
            this.dateField.AutoCheck = false;
            this.dateField.AutoSize = true;
            this.dateField.Checked = true;
            this.dateField.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dateField.Enabled = false;
            this.dateField.Location = new System.Drawing.Point(12, 240);
            this.dateField.Name = "dateField";
            this.dateField.Size = new System.Drawing.Size(57, 17);
            this.dateField.TabIndex = 1;
            this.dateField.Text = "Datum";
            this.dateField.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mogelijke velden voor dit element:";
            // 
            // departmentCheck
            // 
            this.departmentCheck.AutoSize = true;
            this.departmentCheck.Location = new System.Drawing.Point(12, 263);
            this.departmentCheck.Name = "departmentCheck";
            this.departmentCheck.Size = new System.Drawing.Size(64, 17);
            this.departmentCheck.TabIndex = 3;
            this.departmentCheck.Text = "Afdeling";
            this.departmentCheck.UseVisualStyleBackColor = true;
            this.departmentCheck.CheckedChanged += new System.EventHandler(this.departmentCheck_CheckedChanged);
            // 
            // orderNumberCheck
            // 
            this.orderNumberCheck.AutoSize = true;
            this.orderNumberCheck.Location = new System.Drawing.Point(12, 286);
            this.orderNumberCheck.Name = "orderNumberCheck";
            this.orderNumberCheck.Size = new System.Drawing.Size(126, 17);
            this.orderNumberCheck.TabIndex = 4;
            this.orderNumberCheck.Text = "Termijnorder Nummer";
            this.orderNumberCheck.UseVisualStyleBackColor = true;
            this.orderNumberCheck.CheckedChanged += new System.EventHandler(this.orderNumberCheck_CheckedChanged);
            // 
            // pickbonCheck
            // 
            this.pickbonCheck.AutoSize = true;
            this.pickbonCheck.Location = new System.Drawing.Point(12, 309);
            this.pickbonCheck.Name = "pickbonCheck";
            this.pickbonCheck.Size = new System.Drawing.Size(107, 17);
            this.pickbonCheck.TabIndex = 5;
            this.pickbonCheck.Text = "Pickbon Nummer";
            this.pickbonCheck.UseVisualStyleBackColor = true;
            this.pickbonCheck.CheckedChanged += new System.EventHandler(this.pickbonCheck_CheckedChanged);
            // 
            // customerNameCheck
            // 
            this.customerNameCheck.AutoSize = true;
            this.customerNameCheck.Location = new System.Drawing.Point(12, 332);
            this.customerNameCheck.Name = "customerNameCheck";
            this.customerNameCheck.Size = new System.Drawing.Size(76, 17);
            this.customerNameCheck.TabIndex = 6;
            this.customerNameCheck.Text = "Klantnaam";
            this.customerNameCheck.UseVisualStyleBackColor = true;
            this.customerNameCheck.CheckedChanged += new System.EventHandler(this.customerNameCheck_CheckedChanged);
            // 
            // transporterNameCheck
            // 
            this.transporterNameCheck.AutoSize = true;
            this.transporterNameCheck.Location = new System.Drawing.Point(12, 355);
            this.transporterNameCheck.Name = "transporterNameCheck";
            this.transporterNameCheck.Size = new System.Drawing.Size(86, 17);
            this.transporterNameCheck.TabIndex = 7;
            this.transporterNameCheck.Text = "Transporteur";
            this.transporterNameCheck.UseVisualStyleBackColor = true;
            this.transporterNameCheck.CheckedChanged += new System.EventHandler(this.transporterNameCheck_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoCheck = false;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(12, 378);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Documenttype";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Verplichte velden voor dit element:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoCheck = false;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(12, 194);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Documenttype";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // transporterNameAllowedCheck
            // 
            this.transporterNameAllowedCheck.AutoSize = true;
            this.transporterNameAllowedCheck.Checked = true;
            this.transporterNameAllowedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.transporterNameAllowedCheck.Location = new System.Drawing.Point(12, 171);
            this.transporterNameAllowedCheck.Name = "transporterNameAllowedCheck";
            this.transporterNameAllowedCheck.Size = new System.Drawing.Size(86, 17);
            this.transporterNameAllowedCheck.TabIndex = 15;
            this.transporterNameAllowedCheck.Text = "Transporteur";
            this.transporterNameAllowedCheck.UseVisualStyleBackColor = true;
            this.transporterNameAllowedCheck.CheckedChanged += new System.EventHandler(this.transporterNameAllowedCheck_CheckedChanged);
            // 
            // customerNameAllowedCheck
            // 
            this.customerNameAllowedCheck.AutoSize = true;
            this.customerNameAllowedCheck.Checked = true;
            this.customerNameAllowedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.customerNameAllowedCheck.Location = new System.Drawing.Point(12, 148);
            this.customerNameAllowedCheck.Name = "customerNameAllowedCheck";
            this.customerNameAllowedCheck.Size = new System.Drawing.Size(76, 17);
            this.customerNameAllowedCheck.TabIndex = 14;
            this.customerNameAllowedCheck.Text = "Klantnaam";
            this.customerNameAllowedCheck.UseVisualStyleBackColor = true;
            this.customerNameAllowedCheck.CheckedChanged += new System.EventHandler(this.customerNameAllowedCheck_CheckedChanged);
            // 
            // pickbonAllowedCheck
            // 
            this.pickbonAllowedCheck.AutoSize = true;
            this.pickbonAllowedCheck.Checked = true;
            this.pickbonAllowedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pickbonAllowedCheck.Location = new System.Drawing.Point(12, 125);
            this.pickbonAllowedCheck.Name = "pickbonAllowedCheck";
            this.pickbonAllowedCheck.Size = new System.Drawing.Size(107, 17);
            this.pickbonAllowedCheck.TabIndex = 13;
            this.pickbonAllowedCheck.Text = "Pickbon Nummer";
            this.pickbonAllowedCheck.UseVisualStyleBackColor = true;
            this.pickbonAllowedCheck.CheckedChanged += new System.EventHandler(this.pickbonAllowedCheck_CheckedChanged);
            // 
            // orderNumberAllowedCheck
            // 
            this.orderNumberAllowedCheck.AutoSize = true;
            this.orderNumberAllowedCheck.Checked = true;
            this.orderNumberAllowedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.orderNumberAllowedCheck.Location = new System.Drawing.Point(12, 102);
            this.orderNumberAllowedCheck.Name = "orderNumberAllowedCheck";
            this.orderNumberAllowedCheck.Size = new System.Drawing.Size(126, 17);
            this.orderNumberAllowedCheck.TabIndex = 12;
            this.orderNumberAllowedCheck.Text = "Termijnorder Nummer";
            this.orderNumberAllowedCheck.UseVisualStyleBackColor = true;
            this.orderNumberAllowedCheck.CheckedChanged += new System.EventHandler(this.orderNumberAllowedCheck_CheckedChanged);
            // 
            // departmentAllowedCheck
            // 
            this.departmentAllowedCheck.AutoSize = true;
            this.departmentAllowedCheck.Checked = true;
            this.departmentAllowedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.departmentAllowedCheck.Location = new System.Drawing.Point(12, 79);
            this.departmentAllowedCheck.Name = "departmentAllowedCheck";
            this.departmentAllowedCheck.Size = new System.Drawing.Size(64, 17);
            this.departmentAllowedCheck.TabIndex = 11;
            this.departmentAllowedCheck.Text = "Afdeling";
            this.departmentAllowedCheck.UseVisualStyleBackColor = true;
            this.departmentAllowedCheck.CheckedChanged += new System.EventHandler(this.departmentAllowedCheck_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoCheck = false;
            this.checkBox8.AutoSize = true;
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8.Enabled = false;
            this.checkBox8.Location = new System.Drawing.Point(12, 56);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(57, 17);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Text = "Datum";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 401);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(177, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // EditEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 434);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.transporterNameAllowedCheck);
            this.Controls.Add(this.customerNameAllowedCheck);
            this.Controls.Add(this.pickbonAllowedCheck);
            this.Controls.Add(this.orderNumberAllowedCheck);
            this.Controls.Add(this.departmentAllowedCheck);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.transporterNameCheck);
            this.Controls.Add(this.customerNameCheck);
            this.Controls.Add(this.pickbonCheck);
            this.Controls.Add(this.orderNumberCheck);
            this.Controls.Add(this.departmentCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateField);
            this.Controls.Add(this.nameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditEntryForm";
            this.Text = "Bewerken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox dateField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox departmentCheck;
        private System.Windows.Forms.CheckBox orderNumberCheck;
        private System.Windows.Forms.CheckBox pickbonCheck;
        private System.Windows.Forms.CheckBox customerNameCheck;
        private System.Windows.Forms.CheckBox transporterNameCheck;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox transporterNameAllowedCheck;
        private System.Windows.Forms.CheckBox customerNameAllowedCheck;
        private System.Windows.Forms.CheckBox pickbonAllowedCheck;
        private System.Windows.Forms.CheckBox orderNumberAllowedCheck;
        private System.Windows.Forms.CheckBox departmentAllowedCheck;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Button saveButton;
    }
}