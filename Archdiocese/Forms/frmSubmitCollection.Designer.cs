namespace Archdiocese.Forms
{
    partial class frmSubmitCollection
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCollectionType = new System.Windows.Forms.Label();
            this.cmbCollectionType = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblWeekEnding = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbParishPersons = new System.Windows.Forms.ComboBox();
            this.dtpCollectionDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 41);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(172, 293);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 41);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 41);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCollectionType
            // 
            this.lblCollectionType.AutoSize = true;
            this.lblCollectionType.Location = new System.Drawing.Point(35, 91);
            this.lblCollectionType.Name = "lblCollectionType";
            this.lblCollectionType.Size = new System.Drawing.Size(109, 17);
            this.lblCollectionType.TabIndex = 24;
            this.lblCollectionType.Text = "Collection Type:";
            // 
            // cmbCollectionType
            // 
            this.cmbCollectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollectionType.FormattingEnabled = true;
            this.cmbCollectionType.Location = new System.Drawing.Point(192, 91);
            this.cmbCollectionType.Name = "cmbCollectionType";
            this.cmbCollectionType.Size = new System.Drawing.Size(200, 24);
            this.cmbCollectionType.TabIndex = 1;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(37, 31);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(120, 17);
            this.lblAmount.TabIndex = 22;
            this.lblAmount.Text = "Amount in Rands:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(192, 31);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 22);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Tag = "Mandatory";
            // 
            // lblWeekEnding
            // 
            this.lblWeekEnding.AutoSize = true;
            this.lblWeekEnding.Location = new System.Drawing.Point(35, 242);
            this.lblWeekEnding.Name = "lblWeekEnding";
            this.lblWeekEnding.Size = new System.Drawing.Size(79, 17);
            this.lblWeekEnding.TabIndex = 26;
            this.lblWeekEnding.Text = "Mass Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Parishioner:";
            // 
            // cmbParishPersons
            // 
            this.cmbParishPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParishPersons.FormattingEnabled = true;
            this.cmbParishPersons.Location = new System.Drawing.Point(192, 172);
            this.cmbParishPersons.Name = "cmbParishPersons";
            this.cmbParishPersons.Size = new System.Drawing.Size(200, 24);
            this.cmbParishPersons.TabIndex = 2;
            // 
            // dtpCollectionDate
            // 
            this.dtpCollectionDate.Location = new System.Drawing.Point(192, 242);
            this.dtpCollectionDate.Name = "dtpCollectionDate";
            this.dtpCollectionDate.Size = new System.Drawing.Size(200, 22);
            this.dtpCollectionDate.TabIndex = 29;
            // 
            // frmSubmitCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 369);
            this.ControlBox = false;
            this.Controls.Add(this.dtpCollectionDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbParishPersons);
            this.Controls.Add(this.lblWeekEnding);
            this.Controls.Add(this.lblCollectionType);
            this.Controls.Add(this.cmbCollectionType);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubmitCollection";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Submit Collection Amount";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSubmitCollection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCollectionType;
        private System.Windows.Forms.ComboBox cmbCollectionType;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblWeekEnding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbParishPersons;
        private System.Windows.Forms.DateTimePicker dtpCollectionDate;
    }
}