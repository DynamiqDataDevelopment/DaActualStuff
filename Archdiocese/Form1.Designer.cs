namespace Archdiocese
{
    partial class Form1
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
            OutlookStyleControls.OutlookBarButton outlookBarButton1 = new OutlookStyleControls.OutlookBarButton();
            OutlookStyleControls.OutlookBarButton outlookBarButton2 = new OutlookStyleControls.OutlookBarButton();
            this.outlookBar1 = new OutlookStyleControls.OutlookBar();
            //this.SuspendLayout();
            // 
            // outlookBar1
            // 
            this.outlookBar1.BackColor = System.Drawing.SystemColors.Highlight;
            this.outlookBar1.ButtonHeight = 60;
            outlookBarButton1.Enabled = true;
            outlookBarButton1.Image = null;
            outlookBarButton1.Tag = null;
            outlookBarButton1.Text = "Hi";
            outlookBarButton2.Enabled = true;
            outlookBarButton2.Image = null;
            outlookBarButton2.Tag = null;
            outlookBarButton2.Text = "Ho";
            this.outlookBar1.Buttons.Add(outlookBarButton1);
            this.outlookBar1.Buttons.Add(outlookBarButton2);
            this.outlookBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outlookBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlookBar1.GradientButtonHoverDark = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(192)))), ((int)(((byte)(91)))));
            this.outlookBar1.GradientButtonHoverLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.outlookBar1.GradientButtonNormalDark = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(193)))), ((int)(((byte)(140)))));
            this.outlookBar1.GradientButtonNormalLight = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(207)))));
            this.outlookBar1.GradientButtonSelectedDark = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(150)))), ((int)(((byte)(21)))));
            this.outlookBar1.GradientButtonSelectedLight = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            this.outlookBar1.Location = new System.Drawing.Point(13, 13);
            this.outlookBar1.Name = "outlookBar1";
            this.outlookBar1.SelectedButton = null;
            this.outlookBar1.Size = new System.Drawing.Size(257, 210);
            this.outlookBar1.TabIndex = 0;
            this.outlookBar1.Click += new OutlookStyleControls.OutlookBar.ButtonClickEventHandler(this.outlookBar1_Click);
            this.outlookBar1.Load += new System.EventHandler(this.outlookBar1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.outlookBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private OutlookStyleControls.OutlookBar outlookBar1;
    }
}