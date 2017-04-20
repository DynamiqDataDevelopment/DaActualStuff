namespace Archdiocese.Forms
{
    partial class frmPaymentRequestApprovals
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentRequestApprovals));
            this.grd = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchCodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parishUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.captureUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requesterPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.AllowUserToResizeColumns = false;
            this.grd.AllowUserToResizeRows = false;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.fromAccountNumber,
            this.recipientName,
            this.toAccountNumber,
            this.branchCodeID,
            this.bankBranchCode,
            this.parishUserID,
            this.captureUsername,
            this.parishName,
            this.requesterPersonID,
            this.requester,
            this.requestDateTime,
            this.actionDate,
            this.isDeleted});
            this.grd.Location = new System.Drawing.Point(37, 164);
            this.grd.MultiSelect = false;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowTemplate.Height = 24;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd.Size = new System.Drawing.Size(805, 371);
            this.grd.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // fromAccountNumber
            // 
            this.fromAccountNumber.DataPropertyName = "fromAccountNumber";
            this.fromAccountNumber.HeaderText = "From Account";
            this.fromAccountNumber.Name = "fromAccountNumber";
            this.fromAccountNumber.ReadOnly = true;
            // 
            // recipientName
            // 
            this.recipientName.DataPropertyName = "recipientName";
            this.recipientName.HeaderText = "Recipient";
            this.recipientName.Name = "recipientName";
            this.recipientName.ReadOnly = true;
            // 
            // toAccountNumber
            // 
            this.toAccountNumber.DataPropertyName = "toAccountNumber";
            this.toAccountNumber.HeaderText = "To Account";
            this.toAccountNumber.Name = "toAccountNumber";
            this.toAccountNumber.ReadOnly = true;
            // 
            // branchCodeID
            // 
            this.branchCodeID.DataPropertyName = "branchCodeID";
            this.branchCodeID.HeaderText = "branchCodeID";
            this.branchCodeID.Name = "branchCodeID";
            this.branchCodeID.ReadOnly = true;
            this.branchCodeID.Visible = false;
            // 
            // bankBranchCode
            // 
            this.bankBranchCode.DataPropertyName = "bankBranchCode";
            this.bankBranchCode.HeaderText = "Branch Code";
            this.bankBranchCode.Name = "bankBranchCode";
            this.bankBranchCode.ReadOnly = true;
            // 
            // parishUserID
            // 
            this.parishUserID.DataPropertyName = "parishUserID";
            this.parishUserID.HeaderText = "parishUserID";
            this.parishUserID.Name = "parishUserID";
            this.parishUserID.ReadOnly = true;
            this.parishUserID.Visible = false;
            // 
            // captureUsername
            // 
            this.captureUsername.DataPropertyName = "captureUsername";
            this.captureUsername.HeaderText = "Capture Username";
            this.captureUsername.Name = "captureUsername";
            this.captureUsername.ReadOnly = true;
            // 
            // parishName
            // 
            this.parishName.DataPropertyName = "parishName";
            this.parishName.HeaderText = "Parish";
            this.parishName.Name = "parishName";
            this.parishName.ReadOnly = true;
            // 
            // requesterPersonID
            // 
            this.requesterPersonID.DataPropertyName = "requesterPersonID";
            this.requesterPersonID.HeaderText = "requesterPersonID";
            this.requesterPersonID.Name = "requesterPersonID";
            this.requesterPersonID.ReadOnly = true;
            this.requesterPersonID.Visible = false;
            // 
            // requester
            // 
            this.requester.DataPropertyName = "requester";
            this.requester.HeaderText = "Requester";
            this.requester.Name = "requester";
            this.requester.ReadOnly = true;
            // 
            // requestDateTime
            // 
            this.requestDateTime.DataPropertyName = "requestDateTime";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.requestDateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.requestDateTime.HeaderText = "Request Date";
            this.requestDateTime.Name = "requestDateTime";
            this.requestDateTime.ReadOnly = true;
            // 
            // actionDate
            // 
            this.actionDate.DataPropertyName = "actionDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.actionDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.actionDate.HeaderText = "Action Date";
            this.actionDate.Name = "actionDate";
            this.actionDate.ReadOnly = true;
            // 
            // isDeleted
            // 
            this.isDeleted.DataPropertyName = "isDeleted";
            this.isDeleted.HeaderText = "isDeleted";
            this.isDeleted.Name = "isDeleted";
            this.isDeleted.ReadOnly = true;
            this.isDeleted.Visible = false;
            // 
            // btnDecline
            // 
            this.btnDecline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecline.Image = ((System.Drawing.Image)(resources.GetObject("btnDecline.Image")));
            this.btnDecline.Location = new System.Drawing.Point(717, 39);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(125, 100);
            this.btnDecline.TabIndex = 19;
            this.btnDecline.Text = "Decline";
            this.btnDecline.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.Location = new System.Drawing.Point(37, 39);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(125, 100);
            this.btnApprove.TabIndex = 18;
            this.btnApprove.Text = "Approve";
            this.btnApprove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // frmPaymentRequestApprovals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 545);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.grd);
            this.Name = "frmPaymentRequestApprovals";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Payment Approval Form";
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn toAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchCodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn parishUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn captureUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn parishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn requesterPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn requester;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDeleted;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnApprove;
    }
}