namespace Archdiocese.Forms
{
    partial class frmClergy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClergy));
            this.dtpConfirmed = new System.Windows.Forms.DateTimePicker();
            this.dtpBaptised = new System.Windows.Forms.DateTimePicker();
            this.chkConfirmed = new System.Windows.Forms.CheckBox();
            this.chkBaptised = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelephoneNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpJoinedDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.dtpOrdained = new System.Windows.Forms.DateTimePicker();
            this.chkOrdained = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpConfirmed
            // 
            this.dtpConfirmed.Location = new System.Drawing.Point(450, 293);
            this.dtpConfirmed.Name = "dtpConfirmed";
            this.dtpConfirmed.Size = new System.Drawing.Size(150, 22);
            this.dtpConfirmed.TabIndex = 99;
            this.dtpConfirmed.Visible = false;
            // 
            // dtpBaptised
            // 
            this.dtpBaptised.Location = new System.Drawing.Point(450, 247);
            this.dtpBaptised.Name = "dtpBaptised";
            this.dtpBaptised.Size = new System.Drawing.Size(150, 22);
            this.dtpBaptised.TabIndex = 98;
            this.dtpBaptised.Visible = false;
            // 
            // chkConfirmed
            // 
            this.chkConfirmed.AutoSize = true;
            this.chkConfirmed.Location = new System.Drawing.Point(353, 293);
            this.chkConfirmed.Name = "chkConfirmed";
            this.chkConfirmed.Size = new System.Drawing.Size(94, 21);
            this.chkConfirmed.TabIndex = 97;
            this.chkConfirmed.Text = "Confirmed";
            this.chkConfirmed.UseVisualStyleBackColor = true;
            this.chkConfirmed.CheckedChanged += new System.EventHandler(this.chkConfirmed_CheckedChanged);
            // 
            // chkBaptised
            // 
            this.chkBaptised.AutoSize = true;
            this.chkBaptised.Location = new System.Drawing.Point(353, 247);
            this.chkBaptised.Name = "chkBaptised";
            this.chkBaptised.Size = new System.Drawing.Size(85, 21);
            this.chkBaptised.TabIndex = 96;
            this.chkBaptised.Text = "Baptised";
            this.chkBaptised.UseVisualStyleBackColor = true;
            this.chkBaptised.CheckedChanged += new System.EventHandler(this.chkBaptised_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(673, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 17);
            this.label11.TabIndex = 95;
            this.label11.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(785, 248);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 22);
            this.txtCity.TabIndex = 81;
            this.txtCity.Tag = "Mandatory";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(673, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 94;
            this.label12.Text = "Suburb";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(785, 200);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(150, 22);
            this.txtSuburb.TabIndex = 79;
            this.txtSuburb.Tag = "Mandatory";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(673, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 17);
            this.label13.TabIndex = 93;
            this.label13.Text = "Address Line 2";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Location = new System.Drawing.Point(785, 103);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(150, 22);
            this.txtAddressLine2.TabIndex = 76;
            this.txtAddressLine2.Tag = "Optional";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(673, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 17);
            this.label14.TabIndex = 92;
            this.label14.Text = "Address Line 3";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(785, 153);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(150, 22);
            this.txtAddressLine3.TabIndex = 78;
            this.txtAddressLine3.Tag = "Optional";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(673, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 17);
            this.label15.TabIndex = 91;
            this.label15.Text = "Address Line 1";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Location = new System.Drawing.Point(785, 53);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(150, 22);
            this.txtAddressLine1.TabIndex = 75;
            this.txtAddressLine1.Tag = "Mandatory";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 90;
            this.label10.Text = "Tel Number";
            // 
            // txtTelephoneNumber
            // 
            this.txtTelephoneNumber.Location = new System.Drawing.Point(125, 295);
            this.txtTelephoneNumber.Name = "txtTelephoneNumber";
            this.txtTelephoneNumber.Size = new System.Drawing.Size(150, 22);
            this.txtTelephoneNumber.TabIndex = 66;
            this.txtTelephoneNumber.Tag = "Mandatory";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 89;
            this.label9.Text = "Email";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(125, 247);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(150, 22);
            this.txtEmailAddress.TabIndex = 64;
            this.txtEmailAddress.Tag = "Mandatory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(350, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 88;
            this.label8.Text = "Date Joined";
            // 
            // dtpJoinedDate
            // 
            this.dtpJoinedDate.Location = new System.Drawing.Point(450, 197);
            this.dtpJoinedDate.Name = "dtpJoinedDate";
            this.dtpJoinedDate.Size = new System.Drawing.Size(150, 22);
            this.dtpJoinedDate.TabIndex = 73;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(848, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 100);
            this.btnCancel.TabIndex = 86;
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
            this.btnClear.Location = new System.Drawing.Point(450, 435);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 100);
            this.btnClear.TabIndex = 85;
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
            this.btnSave.Location = new System.Drawing.Point(125, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 100);
            this.btnSave.TabIndex = 82;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(986, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 25);
            this.button3.TabIndex = 87;
            this.button3.Text = "Telephone Numbers";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(986, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 25);
            this.button2.TabIndex = 84;
            this.button2.Text = "Email Addresses";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(986, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 25);
            this.button1.TabIndex = 83;
            this.button1.Text = "Addresses";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 80;
            this.label7.Text = "D.O.B.";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(450, 150);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 22);
            this.dtpDateOfBirth.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 77;
            this.label6.Text = "Middle Names";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(125, 150);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(150, 22);
            this.txtMiddleName.TabIndex = 61;
            this.txtMiddleName.Tag = "Optional";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(450, 50);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(150, 24);
            this.cmbGender.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "Surname";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(125, 200);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(150, 22);
            this.txtSurname.TabIndex = 62;
            this.txtSurname.Tag = "Mandatory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(125, 100);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 22);
            this.txtFirstName.TabIndex = 60;
            this.txtFirstName.Tag = "Mandatory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(450, 100);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(150, 24);
            this.cmbType.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Title";
            // 
            // cmbTitle
            // 
            this.cmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(125, 50);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(150, 24);
            this.cmbTitle.TabIndex = 58;
            // 
            // dtpOrdained
            // 
            this.dtpOrdained.Location = new System.Drawing.Point(450, 344);
            this.dtpOrdained.Name = "dtpOrdained";
            this.dtpOrdained.Size = new System.Drawing.Size(150, 22);
            this.dtpOrdained.TabIndex = 101;
            this.dtpOrdained.Visible = false;
            // 
            // chkOrdained
            // 
            this.chkOrdained.AutoSize = true;
            this.chkOrdained.Location = new System.Drawing.Point(353, 344);
            this.chkOrdained.Name = "chkOrdained";
            this.chkOrdained.Size = new System.Drawing.Size(89, 21);
            this.chkOrdained.TabIndex = 100;
            this.chkOrdained.Text = "Ordained";
            this.chkOrdained.UseVisualStyleBackColor = true;
            this.chkOrdained.CheckedChanged += new System.EventHandler(this.chkOrdained_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(673, 295);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 17);
            this.label18.TabIndex = 103;
            this.label18.Text = "Postal Code";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(785, 295);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(150, 22);
            this.txtPostalCode.TabIndex = 102;
            this.txtPostalCode.Tag = "Mandatory";
            // 
            // frmClergy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 644);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.dtpOrdained);
            this.Controls.Add(this.chkOrdained);
            this.Controls.Add(this.dtpConfirmed);
            this.Controls.Add(this.dtpBaptised);
            this.Controls.Add(this.chkConfirmed);
            this.Controls.Add(this.chkBaptised);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSuburb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAddressLine2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAddressLine3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtAddressLine1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTelephoneNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpJoinedDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTitle);
            this.Name = "frmClergy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Priests";
            this.Load += new System.EventHandler(this.frmClergy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpConfirmed;
        private System.Windows.Forms.DateTimePicker dtpBaptised;
        private System.Windows.Forms.CheckBox chkConfirmed;
        private System.Windows.Forms.CheckBox chkBaptised;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelephoneNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpJoinedDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTitle;
        private System.Windows.Forms.DateTimePicker dtpOrdained;
        private System.Windows.Forms.CheckBox chkOrdained;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPostalCode;
    }
}