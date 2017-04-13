namespace Archdiocese.Forms
{
    partial class frmUsersMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsersMenu));
            this.btnUserMaintenance = new System.Windows.Forms.Button();
            this.btnUserGroupMaintenance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUserMaintenance
            // 
            this.btnUserMaintenance.BackColor = System.Drawing.Color.Red;
            this.btnUserMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("btnUserMaintenance.Image")));
            this.btnUserMaintenance.Location = new System.Drawing.Point(75, 50);
            this.btnUserMaintenance.Name = "btnUserMaintenance";
            this.btnUserMaintenance.Size = new System.Drawing.Size(150, 75);
            this.btnUserMaintenance.TabIndex = 0;
            this.btnUserMaintenance.Text = "Persons";
            this.btnUserMaintenance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUserMaintenance.UseVisualStyleBackColor = false;
            this.btnUserMaintenance.MouseLeave += new System.EventHandler(this.btnUserMaintenance_MouseLeave);
            this.btnUserMaintenance.MouseHover += new System.EventHandler(this.btnUserMaintenance_MouseHover);
            // 
            // btnUserGroupMaintenance
            // 
            this.btnUserGroupMaintenance.BackColor = System.Drawing.Color.Red;
            this.btnUserGroupMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserGroupMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserGroupMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("btnUserGroupMaintenance.Image")));
            this.btnUserGroupMaintenance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUserGroupMaintenance.Location = new System.Drawing.Point(300, 50);
            this.btnUserGroupMaintenance.Name = "btnUserGroupMaintenance";
            this.btnUserGroupMaintenance.Size = new System.Drawing.Size(150, 75);
            this.btnUserGroupMaintenance.TabIndex = 1;
            this.btnUserGroupMaintenance.Text = "Person Types";
            this.btnUserGroupMaintenance.UseVisualStyleBackColor = false;
            this.btnUserGroupMaintenance.MouseLeave += new System.EventHandler(this.btnUserGroupMaintenance_MouseLeave);
            this.btnUserGroupMaintenance.MouseHover += new System.EventHandler(this.btnUserGroupMaintenance_MouseHover);
            // 
            // frmUsersMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(577, 357);
            this.Controls.Add(this.btnUserGroupMaintenance);
            this.Controls.Add(this.btnUserMaintenance);
            this.Name = "frmUsersMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "People Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserMaintenance;
        private System.Windows.Forms.Button btnUserGroupMaintenance;
    }
}