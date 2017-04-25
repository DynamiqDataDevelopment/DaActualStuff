namespace Archdiocese.Forms
{
    partial class frmParishPersonsView
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
            this.grd = new System.Windows.Forms.DataGridView();
            this.personID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maritalStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maritalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parishID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLine3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suburb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephoneNumberTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephoneNumberTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personID,
            this.titleID,
            this.title,
            this.personTypeID,
            this.personType,
            this.firstName,
            this.middleName,
            this.surname,
            this.dateOfBirth,
            this.genderID,
            this.gender,
            this.maritalStatusID,
            this.maritalStatus,
            this.parishID,
            this.parishName,
            this.joinedDate,
            this.leftDate,
            this.addressLine1,
            this.addressLine2,
            this.addressLine3,
            this.addressTypeID,
            this.addressTypeDescription,
            this.city,
            this.suburb,
            this.postalCode,
            this.emailAddress,
            this.emailTypeID,
            this.emailTypeDescription,
            this.telephoneNumber,
            this.telephoneNumberTypeID,
            this.telephoneNumberTypeDescription});
            this.grd.Location = new System.Drawing.Point(30, 100);
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowTemplate.Height = 24;
            this.grd.Size = new System.Drawing.Size(824, 150);
            this.grd.TabIndex = 0;
            // 
            // personID
            // 
            this.personID.DataPropertyName = "personID";
            this.personID.HeaderText = "personID";
            this.personID.Name = "personID";
            this.personID.ReadOnly = true;
            this.personID.Visible = false;
            // 
            // titleID
            // 
            this.titleID.DataPropertyName = "titleID";
            this.titleID.HeaderText = "titleID";
            this.titleID.Name = "titleID";
            this.titleID.ReadOnly = true;
            this.titleID.Visible = false;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // personTypeID
            // 
            this.personTypeID.DataPropertyName = "personTypeID";
            this.personTypeID.HeaderText = "personTypeID";
            this.personTypeID.Name = "personTypeID";
            this.personTypeID.ReadOnly = true;
            this.personTypeID.Visible = false;
            // 
            // personType
            // 
            this.personType.DataPropertyName = "personType";
            this.personType.HeaderText = "Person Type";
            this.personType.Name = "personType";
            this.personType.ReadOnly = true;
            // 
            // firstName
            // 
            this.firstName.DataPropertyName = "firstName";
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // middleName
            // 
            this.middleName.DataPropertyName = "middleName";
            this.middleName.HeaderText = "Middle Name";
            this.middleName.Name = "middleName";
            this.middleName.ReadOnly = true;
            // 
            // surname
            // 
            this.surname.DataPropertyName = "surname";
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            // 
            // dateOfBirth
            // 
            this.dateOfBirth.DataPropertyName = "dateOfBirth";
            this.dateOfBirth.HeaderText = "D.O.B.";
            this.dateOfBirth.Name = "dateOfBirth";
            this.dateOfBirth.ReadOnly = true;
            // 
            // genderID
            // 
            this.genderID.DataPropertyName = "genderID";
            this.genderID.HeaderText = "genderID";
            this.genderID.Name = "genderID";
            this.genderID.ReadOnly = true;
            this.genderID.Visible = false;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // maritalStatusID
            // 
            this.maritalStatusID.DataPropertyName = "maritalStatusID";
            this.maritalStatusID.HeaderText = "maritalStatusID";
            this.maritalStatusID.Name = "maritalStatusID";
            this.maritalStatusID.ReadOnly = true;
            this.maritalStatusID.Visible = false;
            // 
            // maritalStatus
            // 
            this.maritalStatus.DataPropertyName = "maritalStatus";
            this.maritalStatus.HeaderText = "Marital Status";
            this.maritalStatus.Name = "maritalStatus";
            this.maritalStatus.ReadOnly = true;
            // 
            // parishID
            // 
            this.parishID.DataPropertyName = "parishID";
            this.parishID.HeaderText = "parishID";
            this.parishID.Name = "parishID";
            this.parishID.ReadOnly = true;
            this.parishID.Visible = false;
            // 
            // parishName
            // 
            this.parishName.DataPropertyName = "parishName";
            this.parishName.HeaderText = "Parish";
            this.parishName.Name = "parishName";
            this.parishName.ReadOnly = true;
            // 
            // joinedDate
            // 
            this.joinedDate.DataPropertyName = "joinedDate";
            this.joinedDate.HeaderText = "Date Joined";
            this.joinedDate.Name = "joinedDate";
            this.joinedDate.ReadOnly = true;
            // 
            // leftDate
            // 
            this.leftDate.DataPropertyName = "leftDate";
            this.leftDate.HeaderText = "leftDate";
            this.leftDate.Name = "leftDate";
            this.leftDate.ReadOnly = true;
            // 
            // addressLine1
            // 
            this.addressLine1.DataPropertyName = "addressLine1";
            this.addressLine1.HeaderText = "Address Line 1";
            this.addressLine1.Name = "addressLine1";
            this.addressLine1.ReadOnly = true;
            // 
            // addressLine2
            // 
            this.addressLine2.DataPropertyName = "addressLine2";
            this.addressLine2.HeaderText = "Address Line 2";
            this.addressLine2.Name = "addressLine2";
            this.addressLine2.ReadOnly = true;
            // 
            // addressLine3
            // 
            this.addressLine3.DataPropertyName = "addressLine3";
            this.addressLine3.HeaderText = "Address Line 3";
            this.addressLine3.Name = "addressLine3";
            this.addressLine3.ReadOnly = true;
            // 
            // addressTypeID
            // 
            this.addressTypeID.DataPropertyName = "addressTypeID";
            this.addressTypeID.HeaderText = "addressTypeID";
            this.addressTypeID.Name = "addressTypeID";
            this.addressTypeID.ReadOnly = true;
            this.addressTypeID.Visible = false;
            // 
            // addressTypeDescription
            // 
            this.addressTypeDescription.DataPropertyName = "addressTypeDescription";
            this.addressTypeDescription.HeaderText = "Address Type";
            this.addressTypeDescription.Name = "addressTypeDescription";
            this.addressTypeDescription.ReadOnly = true;
            // 
            // city
            // 
            this.city.DataPropertyName = "city";
            this.city.HeaderText = "City";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // suburb
            // 
            this.suburb.DataPropertyName = "suburb";
            this.suburb.HeaderText = "Suburb";
            this.suburb.Name = "suburb";
            this.suburb.ReadOnly = true;
            // 
            // postalCode
            // 
            this.postalCode.DataPropertyName = "postalCode";
            this.postalCode.HeaderText = "Postal Code";
            this.postalCode.Name = "postalCode";
            this.postalCode.ReadOnly = true;
            // 
            // emailAddress
            // 
            this.emailAddress.DataPropertyName = "emailAddress";
            this.emailAddress.HeaderText = "Email";
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.ReadOnly = true;
            // 
            // emailTypeID
            // 
            this.emailTypeID.DataPropertyName = "emailTypeID";
            this.emailTypeID.HeaderText = "emailTypeID";
            this.emailTypeID.Name = "emailTypeID";
            this.emailTypeID.ReadOnly = true;
            this.emailTypeID.Visible = false;
            // 
            // emailTypeDescription
            // 
            this.emailTypeDescription.DataPropertyName = "emailTypeDescription";
            this.emailTypeDescription.HeaderText = "Email Type";
            this.emailTypeDescription.Name = "emailTypeDescription";
            this.emailTypeDescription.ReadOnly = true;
            // 
            // telephoneNumber
            // 
            this.telephoneNumber.DataPropertyName = "telephoneNumber";
            this.telephoneNumber.HeaderText = "Tel. No.";
            this.telephoneNumber.Name = "telephoneNumber";
            this.telephoneNumber.ReadOnly = true;
            // 
            // telephoneNumberTypeID
            // 
            this.telephoneNumberTypeID.DataPropertyName = "telephoneNumberTypeID";
            this.telephoneNumberTypeID.HeaderText = "telephoneNumberTypeID";
            this.telephoneNumberTypeID.Name = "telephoneNumberTypeID";
            this.telephoneNumberTypeID.ReadOnly = true;
            this.telephoneNumberTypeID.Visible = false;
            // 
            // telephoneNumberTypeDescription
            // 
            this.telephoneNumberTypeDescription.DataPropertyName = "telephoneNumberTypeDescription";
            this.telephoneNumberTypeDescription.HeaderText = "Tel. No. Type";
            this.telephoneNumberTypeDescription.Name = "telephoneNumberTypeDescription";
            this.telephoneNumberTypeDescription.ReadOnly = true;
            // 
            // frmParishPersonsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 455);
            this.Controls.Add(this.grd);
            this.Name = "frmParishPersonsView";
            this.Text = "Search Persons";
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.DataGridViewTextBoxColumn personID;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn personTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn personType;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn maritalStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn maritalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn parishID;
        private System.Windows.Forms.DataGridViewTextBoxColumn parishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLine3;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressTypeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn suburb;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailTypeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephoneNumberTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephoneNumberTypeDescription;
    }
}