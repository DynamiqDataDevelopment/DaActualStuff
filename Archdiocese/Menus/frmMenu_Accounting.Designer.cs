namespace Archdiocese.Menus
{
    partial class frmMenu_Accounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu_Accounting));
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnAccountsSetup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPaymentApprovals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIncome
            // 
            this.btnIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncome.Image = ((System.Drawing.Image)(resources.GetObject("btnIncome.Image")));
            this.btnIncome.Location = new System.Drawing.Point(70, 50);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(125, 100);
            this.btnIncome.TabIndex = 4;
            this.btnIncome.Text = "Income";
            this.btnIncome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Visible = false;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            this.btnIncome.MouseLeave += new System.EventHandler(this.btnIncome_MouseLeave);
            this.btnIncome.MouseHover += new System.EventHandler(this.btnIncome_MouseHover);
            // 
            // btnExpense
            // 
            this.btnExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpense.Image = ((System.Drawing.Image)(resources.GetObject("btnExpense.Image")));
            this.btnExpense.Location = new System.Drawing.Point(320, 50);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(125, 100);
            this.btnExpense.TabIndex = 3;
            this.btnExpense.Text = "Accounting Search";
            this.btnExpense.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            this.btnExpense.MouseLeave += new System.EventHandler(this.btnExpense_MouseLeave);
            this.btnExpense.MouseHover += new System.EventHandler(this.btnExpense_MouseHover);
            // 
            // btnAccountsSetup
            // 
            this.btnAccountsSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountsSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountsSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountsSetup.Image")));
            this.btnAccountsSetup.Location = new System.Drawing.Point(570, 50);
            this.btnAccountsSetup.Name = "btnAccountsSetup";
            this.btnAccountsSetup.Size = new System.Drawing.Size(125, 100);
            this.btnAccountsSetup.TabIndex = 5;
            this.btnAccountsSetup.Text = "Accounting";
            this.btnAccountsSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAccountsSetup.UseVisualStyleBackColor = true;
            this.btnAccountsSetup.Click += new System.EventHandler(this.btnAccountsSetup_Click);
            this.btnAccountsSetup.MouseLeave += new System.EventHandler(this.btnAccountsSetup_MouseLeave);
            this.btnAccountsSetup.MouseHover += new System.EventHandler(this.btnAccountsSetup_MouseHover);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(825, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 100);
            this.button1.TabIndex = 6;
            this.button1.Text = "Payment Requests";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPaymentApprovals
            // 
            this.btnPaymentApprovals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaymentApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentApprovals.Image = ((System.Drawing.Image)(resources.GetObject("btnPaymentApprovals.Image")));
            this.btnPaymentApprovals.Location = new System.Drawing.Point(1060, 50);
            this.btnPaymentApprovals.Name = "btnPaymentApprovals";
            this.btnPaymentApprovals.Size = new System.Drawing.Size(125, 100);
            this.btnPaymentApprovals.TabIndex = 7;
            this.btnPaymentApprovals.Text = "Payment Approvals";
            this.btnPaymentApprovals.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPaymentApprovals.UseVisualStyleBackColor = true;
            this.btnPaymentApprovals.Click += new System.EventHandler(this.btnPaymentApprovals_Click);
            // 
            // frmMenu_Accounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 735);
            this.Controls.Add(this.btnPaymentApprovals);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAccountsSetup);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.btnExpense);
            this.Name = "frmMenu_Accounting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Accounting Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnAccountsSetup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPaymentApprovals;
    }
}