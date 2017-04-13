namespace Archdiocese.Forms
{
    partial class frmUserGroupsView
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
            this.grdUserGroups = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGroupDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUserGroups
            // 
            this.grdUserGroups.AllowUserToAddRows = false;
            this.grdUserGroups.AllowUserToDeleteRows = false;
            this.grdUserGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUserGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.userGroupDescription,
            this.status});
            this.grdUserGroups.Location = new System.Drawing.Point(30, 31);
            this.grdUserGroups.Name = "grdUserGroups";
            this.grdUserGroups.ReadOnly = true;
            this.grdUserGroups.RowTemplate.Height = 24;
            this.grdUserGroups.Size = new System.Drawing.Size(811, 363);
            this.grdUserGroups.TabIndex = 0;
            this.grdUserGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUserGroups_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // userGroupDescription
            // 
            this.userGroupDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userGroupDescription.DataPropertyName = "userGroupDescription";
            this.userGroupDescription.HeaderText = "User Group";
            this.userGroupDescription.Name = "userGroupDescription";
            this.userGroupDescription.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // frmUserGroupsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 545);
            this.ControlBox = false;
            this.Controls.Add(this.grdUserGroups);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserGroupsView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "User Groups";
            this.Load += new System.EventHandler(this.frmUserGroupsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdUserGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGroupDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}