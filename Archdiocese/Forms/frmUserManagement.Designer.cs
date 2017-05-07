namespace Archdiocese.Forms
{
    partial class frmUserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserManagement));
            this.tbUserManagement = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.tabUserGroups = new System.Windows.Forms.TabPage();
            this.tabParishUsers = new System.Windows.Forms.TabPage();
            this.btnClearUser = new System.Windows.Forms.Button();
            this.cmbUserGroup = new System.Windows.Forms.ComboBox();
            this.btnCancelUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUserGroups = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUserManagement.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabUserGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUserManagement
            // 
            this.tbUserManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserManagement.Controls.Add(this.tabUsers);
            this.tbUserManagement.Controls.Add(this.tabUserGroups);
            this.tbUserManagement.Controls.Add(this.tabParishUsers);
            this.tbUserManagement.Location = new System.Drawing.Point(13, 13);
            this.tbUserManagement.Name = "tbUserManagement";
            this.tbUserManagement.SelectedIndex = 0;
            this.tbUserManagement.Size = new System.Drawing.Size(854, 508);
            this.tbUserManagement.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.cmbUser);
            this.tabUsers.Controls.Add(this.label4);
            this.tabUsers.Controls.Add(this.btnClearUser);
            this.tabUsers.Controls.Add(this.cmbUserGroup);
            this.tabUsers.Controls.Add(this.btnCancelUser);
            this.tabUsers.Controls.Add(this.btnSaveUser);
            this.tabUsers.Controls.Add(this.label3);
            this.tabUsers.Controls.Add(this.txtPassword);
            this.tabUsers.Controls.Add(this.label2);
            this.tabUsers.Controls.Add(this.txtUsername);
            this.tabUsers.Controls.Add(this.label1);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(846, 479);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // tabUserGroups
            // 
            this.tabUserGroups.Controls.Add(this.cmbUserGroups);
            this.tabUserGroups.Controls.Add(this.label5);
            this.tabUserGroups.Location = new System.Drawing.Point(4, 25);
            this.tabUserGroups.Name = "tabUserGroups";
            this.tabUserGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserGroups.Size = new System.Drawing.Size(846, 479);
            this.tabUserGroups.TabIndex = 1;
            this.tabUserGroups.Text = "User Groups";
            this.tabUserGroups.UseVisualStyleBackColor = true;
            // 
            // tabParishUsers
            // 
            this.tabParishUsers.Location = new System.Drawing.Point(4, 25);
            this.tabParishUsers.Name = "tabParishUsers";
            this.tabParishUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabParishUsers.Size = new System.Drawing.Size(846, 479);
            this.tabParishUsers.TabIndex = 2;
            this.tabParishUsers.Text = "Parish Users";
            this.tabParishUsers.UseVisualStyleBackColor = true;
            // 
            // btnClearUser
            // 
            this.btnClearUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearUser.Image = ((System.Drawing.Image)(resources.GetObject("btnClearUser.Image")));
            this.btnClearUser.Location = new System.Drawing.Point(169, 388);
            this.btnClearUser.Name = "btnClearUser";
            this.btnClearUser.Size = new System.Drawing.Size(75, 75);
            this.btnClearUser.TabIndex = 38;
            this.btnClearUser.Text = "Clear";
            this.btnClearUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearUser.UseVisualStyleBackColor = true;
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserGroup.FormattingEnabled = true;
            this.cmbUserGroup.Location = new System.Drawing.Point(205, 319);
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.Size = new System.Drawing.Size(178, 24);
            this.cmbUserGroup.TabIndex = 37;
            // 
            // btnCancelUser
            // 
            this.btnCancelUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelUser.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelUser.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelUser.Image")));
            this.btnCancelUser.Location = new System.Drawing.Point(308, 388);
            this.btnCancelUser.Name = "btnCancelUser";
            this.btnCancelUser.Size = new System.Drawing.Size(75, 75);
            this.btnCancelUser.TabIndex = 36;
            this.btnCancelUser.Text = "Cancel";
            this.btnCancelUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelUser.UseVisualStyleBackColor = true;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUser.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveUser.Image")));
            this.btnSaveUser.Location = new System.Drawing.Point(25, 388);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(75, 75);
            this.btnSaveUser.TabIndex = 35;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveUser.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "User Group";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(205, 244);
            this.txtPassword.MaxLength = 8;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 22);
            this.txtPassword.TabIndex = 33;
            this.txtPassword.Tag = "Mandatory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(205, 169);
            this.txtUsername.MaxLength = 8;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(178, 22);
            this.txtUsername.TabIndex = 31;
            this.txtUsername.Tag = "Mandatory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Username";
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(205, 42);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(178, 24);
            this.cmbUser.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Select User to Edit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUserGroups
            // 
            this.cmbUserGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserGroups.FormattingEnabled = true;
            this.cmbUserGroups.Location = new System.Drawing.Point(115, 41);
            this.cmbUserGroups.Name = "cmbUserGroups";
            this.cmbUserGroups.Size = new System.Drawing.Size(178, 24);
            this.cmbUserGroups.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "User Group";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 533);
            this.ControlBox = false;
            this.Controls.Add(this.tbUserManagement);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserManagement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "User Management";
            this.tbUserManagement.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            this.tabUserGroups.ResumeLayout(false);
            this.tabUserGroups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbUserManagement;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabUserGroups;
        private System.Windows.Forms.TabPage tabParishUsers;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearUser;
        private System.Windows.Forms.ComboBox cmbUserGroup;
        private System.Windows.Forms.Button btnCancelUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUserGroups;
        private System.Windows.Forms.Label label5;
    }
}