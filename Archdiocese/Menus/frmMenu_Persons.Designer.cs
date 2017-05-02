namespace Archdiocese.Menus
{
    partial class frmMenu_Persons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu_Persons));
            this.btnPersonType = new System.Windows.Forms.Button();
            this.btnPerson = new System.Windows.Forms.Button();
            this.btnClergy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersonType
            // 
            this.btnPersonType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersonType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonType.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonType.Image")));
            this.btnPersonType.Location = new System.Drawing.Point(320, 50);
            this.btnPersonType.Name = "btnPersonType";
            this.btnPersonType.Size = new System.Drawing.Size(125, 100);
            this.btnPersonType.TabIndex = 1;
            this.btnPersonType.Text = "Person Types";
            this.btnPersonType.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPersonType.UseVisualStyleBackColor = true;
            this.btnPersonType.MouseLeave += new System.EventHandler(this.btnPersonType_MouseLeave);
            this.btnPersonType.MouseHover += new System.EventHandler(this.btnPersonType_MouseHover);
            // 
            // btnPerson
            // 
            this.btnPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnPerson.Image")));
            this.btnPerson.Location = new System.Drawing.Point(70, 50);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(125, 100);
            this.btnPerson.TabIndex = 2;
            this.btnPerson.Text = "Person";
            this.btnPerson.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click_1);
            this.btnPerson.MouseLeave += new System.EventHandler(this.btnPerson_MouseLeave);
            this.btnPerson.MouseHover += new System.EventHandler(this.btnPerson_MouseHover);
            // 
            // btnClergy
            // 
            this.btnClergy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClergy.Image = ((System.Drawing.Image)(resources.GetObject("btnClergy.Image")));
            this.btnClergy.Location = new System.Drawing.Point(70, 237);
            this.btnClergy.Name = "btnClergy";
            this.btnClergy.Size = new System.Drawing.Size(125, 100);
            this.btnClergy.TabIndex = 3;
            this.btnClergy.Text = "Clergy";
            this.btnClergy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClergy.UseVisualStyleBackColor = true;
            this.btnClergy.Click += new System.EventHandler(this.btnClergy_Click);
            // 
            // frmMenu_Persons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 735);
            this.ControlBox = false;
            this.Controls.Add(this.btnClergy);
            this.Controls.Add(this.btnPerson);
            this.Controls.Add(this.btnPersonType);
            this.Name = "frmMenu_Persons";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Person Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPersonType;
        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Button btnClergy;
    }
}