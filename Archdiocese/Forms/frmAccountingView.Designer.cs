namespace Archdiocese.Forms
{
    partial class frmAccountingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountingView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grd = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSubmitted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.captureUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblIncomeTotal = new System.Windows.Forms.Label();
            this.lblExpenseTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.accountNumber,
            this.accountName,
            this.date,
            this.dateSubmitted,
            this.description,
            this.amount,
            this.captureUser});
            this.grd.Location = new System.Drawing.Point(12, 166);
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowTemplate.Height = 24;
            this.grd.Size = new System.Drawing.Size(994, 184);
            this.grd.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(931, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 75);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Date From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(157, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpFrom.TabIndex = 30;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(557, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 22);
            this.dtpTo.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date To:";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(822, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 75);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // type
            // 
            this.type.DataPropertyName = "Type";
            this.type.HeaderText = "Type";
            this.type.MaxInputLength = 1;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.type.ToolTipText = "Income (I) or Expense (E)";
            // 
            // accountNumber
            // 
            this.accountNumber.DataPropertyName = "accountNumber";
            this.accountNumber.HeaderText = "Account Number";
            this.accountNumber.Name = "accountNumber";
            this.accountNumber.ReadOnly = true;
            // 
            // accountName
            // 
            this.accountName.DataPropertyName = "accountName";
            this.accountName.HeaderText = "Account Name";
            this.accountName.Name = "accountName";
            this.accountName.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "theDate";
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            dataGridViewCellStyle10.NullValue = null;
            this.date.DefaultCellStyle = dataGridViewCellStyle10;
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // dateSubmitted
            // 
            this.dateSubmitted.DataPropertyName = "dateSubmitted";
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            dataGridViewCellStyle11.NullValue = null;
            this.dateSubmitted.DefaultCellStyle = dataGridViewCellStyle11;
            this.dateSubmitted.HeaderText = "Date Submitted";
            this.dateSubmitted.Name = "dateSubmitted";
            this.dateSubmitted.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.MaxInputLength = 32;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.amount.DefaultCellStyle = dataGridViewCellStyle12;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // captureUser
            // 
            this.captureUser.DataPropertyName = "captureUser";
            this.captureUser.HeaderText = "Capture User";
            this.captureUser.Name = "captureUser";
            this.captureUser.ReadOnly = true;
            // 
            // lblIncomeTotal
            // 
            this.lblIncomeTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIncomeTotal.AutoSize = true;
            this.lblIncomeTotal.Location = new System.Drawing.Point(12, 375);
            this.lblIncomeTotal.Name = "lblIncomeTotal";
            this.lblIncomeTotal.Size = new System.Drawing.Size(93, 17);
            this.lblIncomeTotal.TabIndex = 34;
            this.lblIncomeTotal.Text = "Total Income:";
            // 
            // lblExpenseTotal
            // 
            this.lblExpenseTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExpenseTotal.AutoSize = true;
            this.lblExpenseTotal.Location = new System.Drawing.Point(12, 411);
            this.lblExpenseTotal.Name = "lblExpenseTotal";
            this.lblExpenseTotal.Size = new System.Drawing.Size(102, 17);
            this.lblExpenseTotal.TabIndex = 35;
            this.lblExpenseTotal.Text = "Total Expense:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 448);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 17);
            this.lblTotal.TabIndex = 36;
            this.lblTotal.Text = "Total:";
            // 
            // frmAccountingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 474);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblExpenseTotal);
            this.Controls.Add(this.lblIncomeTotal);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountingView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Accounting Search";
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSubmitted;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn captureUser;
        private System.Windows.Forms.Label lblIncomeTotal;
        private System.Windows.Forms.Label lblExpenseTotal;
        private System.Windows.Forms.Label lblTotal;
    }
}