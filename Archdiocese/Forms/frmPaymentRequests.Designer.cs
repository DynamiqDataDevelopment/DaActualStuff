namespace Archdiocese.Forms
{
    partial class frmPaymentRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentRequests));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFromAccountNumber = new System.Windows.Forms.TextBox();
            this.cmbBankBranchCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToAccountNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecipientReference = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRequester = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpActionDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Account Number";
            // 
            // txtFromAccountNumber
            // 
            this.txtFromAccountNumber.Location = new System.Drawing.Point(200, 25);
            this.txtFromAccountNumber.Name = "txtFromAccountNumber";
            this.txtFromAccountNumber.Size = new System.Drawing.Size(160, 22);
            this.txtFromAccountNumber.TabIndex = 1;
            this.txtFromAccountNumber.Tag = "Mandatory";
            // 
            // cmbBankBranchCode
            // 
            this.cmbBankBranchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankBranchCode.FormattingEnabled = true;
            this.cmbBankBranchCode.Location = new System.Drawing.Point(594, 100);
            this.cmbBankBranchCode.Name = "cmbBankBranchCode";
            this.cmbBankBranchCode.Size = new System.Drawing.Size(160, 24);
            this.cmbBankBranchCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Branch Code";
            // 
            // txtToAccountNumber
            // 
            this.txtToAccountNumber.Location = new System.Drawing.Point(200, 102);
            this.txtToAccountNumber.Name = "txtToAccountNumber";
            this.txtToAccountNumber.Size = new System.Drawing.Size(160, 22);
            this.txtToAccountNumber.TabIndex = 5;
            this.txtToAccountNumber.Tag = "Mandatory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Account Number";
            // 
            // txtRecipientReference
            // 
            this.txtRecipientReference.Location = new System.Drawing.Point(594, 25);
            this.txtRecipientReference.Name = "txtRecipientReference";
            this.txtRecipientReference.Size = new System.Drawing.Size(160, 22);
            this.txtRecipientReference.TabIndex = 7;
            this.txtRecipientReference.Tag = "Mandatory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Recipient Reference";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(629, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 100);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(337, 290);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 100);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(35, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 100);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(426, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Requester";
            // 
            // cmbRequester
            // 
            this.cmbRequester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequester.FormattingEnabled = true;
            this.cmbRequester.Location = new System.Drawing.Point(594, 187);
            this.cmbRequester.Name = "cmbRequester";
            this.cmbRequester.Size = new System.Drawing.Size(160, 24);
            this.cmbRequester.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Action Date";
            // 
            // dtpActionDate
            // 
            this.dtpActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActionDate.Location = new System.Drawing.Point(200, 187);
            this.dtpActionDate.Name = "dtpActionDate";
            this.dtpActionDate.Size = new System.Drawing.Size(160, 22);
            this.dtpActionDate.TabIndex = 25;
            // 
            // frmPaymentRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 504);
            this.Controls.Add(this.dtpActionDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRequester);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRecipientReference);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtToAccountNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBankBranchCode);
            this.Controls.Add(this.txtFromAccountNumber);
            this.Controls.Add(this.label1);
            this.Name = "frmPaymentRequests";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Payment Requests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFromAccountNumber;
        private System.Windows.Forms.ComboBox cmbBankBranchCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToAccountNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecipientReference;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRequester;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpActionDate;
    }
}