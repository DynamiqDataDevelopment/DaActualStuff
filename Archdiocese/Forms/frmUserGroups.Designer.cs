namespace Archdiocese.Forms
{
    partial class frmUserGroups
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
            this.lblUserGroupDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUserGroupDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUserGroupDescription
            // 
            this.lblUserGroupDescription.AutoSize = true;
            this.lblUserGroupDescription.Location = new System.Drawing.Point(26, 25);
            this.lblUserGroupDescription.Name = "lblUserGroupDescription";
            this.lblUserGroupDescription.Size = new System.Drawing.Size(161, 17);
            this.lblUserGroupDescription.TabIndex = 26;
            this.lblUserGroupDescription.Text = "User Group Description:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 41);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(175, 205);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 41);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 41);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUserGroupDescription
            // 
            this.txtUserGroupDescription.Location = new System.Drawing.Point(197, 25);
            this.txtUserGroupDescription.MaxLength = 16;
            this.txtUserGroupDescription.Name = "txtUserGroupDescription";
            this.txtUserGroupDescription.Size = new System.Drawing.Size(200, 22);
            this.txtUserGroupDescription.TabIndex = 22;
            // 
            // frmUserGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 285);
            this.ControlBox = false;
            this.Controls.Add(this.lblUserGroupDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUserGroupDescription);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserGroups";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Groups";
            this.Load += new System.EventHandler(this.frmUserGroups_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserGroupDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUserGroupDescription;
    }
}