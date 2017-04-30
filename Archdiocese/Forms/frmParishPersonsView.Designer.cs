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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParishPersonsView));
            this.grd = new System.Windows.Forms.DataGridView();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.txtSearchCriteria = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpSearchCriteria = new System.Windows.Forms.DateTimePicker();
            this.cmbSearchCriteria = new System.Windows.Forms.ComboBox();
            this.personID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maritalStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maritalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parishID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joinedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBaptised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateConfirmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pledgeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pledgeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personID,
            this.titleID,
            this.title,
            this.firstName,
            this.middleName,
            this.surname,
            this.dateOfBirth,
            this.personTypeID,
            this.personType,
            this.genderID,
            this.gender,
            this.maritalStatusID,
            this.maritalStatus,
            this.parishID,
            this.parishName,
            this.joinedDate,
            this.leftDate,
            this.dateBaptised,
            this.dateConfirmed,
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
            this.telephoneNumberTypeDescription,
            this.pledgeAmount,
            this.pledgeTypeID});
            this.grd.Location = new System.Drawing.Point(30, 135);
            this.grd.MultiSelect = false;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowTemplate.Height = 24;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd.Size = new System.Drawing.Size(824, 150);
            this.grd.TabIndex = 0;
            this.grd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CellDoubleClick);
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "First Name",
            "Middle Name",
            "Surname",
            "Telephone Number",
            "Email Address"});
            this.cmbSearchBy.Location = new System.Drawing.Point(30, 33);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(200, 24);
            this.cmbSearchBy.TabIndex = 2;
            // 
            // txtSearchCriteria
            // 
            this.txtSearchCriteria.Location = new System.Drawing.Point(30, 90);
            this.txtSearchCriteria.Name = "txtSearchCriteria";
            this.txtSearchCriteria.Size = new System.Drawing.Size(200, 22);
            this.txtSearchCriteria.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(640, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 75);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(779, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 75);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(496, 33);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 75);
            this.btnFilter.TabIndex = 30;
            this.btnFilter.Text = "Filter";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpSearchCriteria
            // 
            this.dtpSearchCriteria.Location = new System.Drawing.Point(30, 90);
            this.dtpSearchCriteria.Name = "dtpSearchCriteria";
            this.dtpSearchCriteria.Size = new System.Drawing.Size(200, 22);
            this.dtpSearchCriteria.TabIndex = 33;
            this.dtpSearchCriteria.Visible = false;
            // 
            // cmbSearchCriteria
            // 
            this.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchCriteria.FormattingEnabled = true;
            this.cmbSearchCriteria.Location = new System.Drawing.Point(30, 90);
            this.cmbSearchCriteria.Name = "cmbSearchCriteria";
            this.cmbSearchCriteria.Size = new System.Drawing.Size(200, 24);
            this.cmbSearchCriteria.TabIndex = 34;
            this.cmbSearchCriteria.Visible = false;
            // 
            // personID
            // 
            this.personID.DataPropertyName = "personID";
            this.personID.HeaderText = "personID";
            this.personID.Name = "personID";
            this.personID.ReadOnly = true;
            this.personID.Visible = false;
            this.personID.Width = 94;
            // 
            // titleID
            // 
            this.titleID.DataPropertyName = "titleID";
            this.titleID.HeaderText = "titleID";
            this.titleID.Name = "titleID";
            this.titleID.ReadOnly = true;
            this.titleID.Visible = false;
            this.titleID.Width = 72;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 64;
            // 
            // firstName
            // 
            this.firstName.DataPropertyName = "firstName";
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 105;
            // 
            // middleName
            // 
            this.middleName.DataPropertyName = "middleName";
            this.middleName.HeaderText = "Middle Name";
            this.middleName.Name = "middleName";
            this.middleName.ReadOnly = true;
            this.middleName.Width = 119;
            // 
            // surname
            // 
            this.surname.DataPropertyName = "surname";
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            this.surname.Width = 94;
            // 
            // dateOfBirth
            // 
            this.dateOfBirth.DataPropertyName = "dateOfBirth";
            this.dateOfBirth.HeaderText = "D.O.B.";
            this.dateOfBirth.Name = "dateOfBirth";
            this.dateOfBirth.ReadOnly = true;
            this.dateOfBirth.Width = 79;
            // 
            // personTypeID
            // 
            this.personTypeID.DataPropertyName = "personTypeID";
            this.personTypeID.HeaderText = "personTypeID";
            this.personTypeID.Name = "personTypeID";
            this.personTypeID.ReadOnly = true;
            this.personTypeID.Visible = false;
            this.personTypeID.Width = 126;
            // 
            // personType
            // 
            this.personType.DataPropertyName = "personType";
            this.personType.HeaderText = "Person Type";
            this.personType.Name = "personType";
            this.personType.ReadOnly = true;
            this.personType.Width = 118;
            // 
            // genderID
            // 
            this.genderID.DataPropertyName = "genderID";
            this.genderID.HeaderText = "genderID";
            this.genderID.Name = "genderID";
            this.genderID.ReadOnly = true;
            this.genderID.Visible = false;
            this.genderID.Width = 95;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 85;
            // 
            // maritalStatusID
            // 
            this.maritalStatusID.DataPropertyName = "maritalStatusID";
            this.maritalStatusID.HeaderText = "maritalStatusID";
            this.maritalStatusID.Name = "maritalStatusID";
            this.maritalStatusID.ReadOnly = true;
            this.maritalStatusID.Visible = false;
            this.maritalStatusID.Width = 132;
            // 
            // maritalStatus
            // 
            this.maritalStatus.DataPropertyName = "maritalStatus";
            this.maritalStatus.HeaderText = "Marital Status";
            this.maritalStatus.Name = "maritalStatus";
            this.maritalStatus.ReadOnly = true;
            this.maritalStatus.Width = 123;
            // 
            // parishID
            // 
            this.parishID.DataPropertyName = "parishID";
            this.parishID.HeaderText = "parishID";
            this.parishID.Name = "parishID";
            this.parishID.ReadOnly = true;
            this.parishID.Visible = false;
            this.parishID.Width = 89;
            // 
            // parishName
            // 
            this.parishName.DataPropertyName = "parishName";
            this.parishName.HeaderText = "Parish";
            this.parishName.Name = "parishName";
            this.parishName.ReadOnly = true;
            this.parishName.Width = 77;
            // 
            // joinedDate
            // 
            this.joinedDate.DataPropertyName = "joinedDate";
            this.joinedDate.HeaderText = "Date Joined";
            this.joinedDate.Name = "joinedDate";
            this.joinedDate.ReadOnly = true;
            this.joinedDate.Width = 113;
            // 
            // leftDate
            // 
            this.leftDate.DataPropertyName = "leftDate";
            this.leftDate.HeaderText = "Date Left";
            this.leftDate.Name = "leftDate";
            this.leftDate.ReadOnly = true;
            this.leftDate.Visible = false;
            this.leftDate.Width = 95;
            // 
            // dateBaptised
            // 
            this.dateBaptised.DataPropertyName = "dateBaptised";
            this.dateBaptised.HeaderText = "Date Baptised";
            this.dateBaptised.Name = "dateBaptised";
            this.dateBaptised.ReadOnly = true;
            this.dateBaptised.Width = 126;
            // 
            // dateConfirmed
            // 
            this.dateConfirmed.DataPropertyName = "dateConfirmed";
            this.dateConfirmed.HeaderText = "Date Confirmed";
            this.dateConfirmed.Name = "dateConfirmed";
            this.dateConfirmed.ReadOnly = true;
            this.dateConfirmed.Width = 124;
            // 
            // addressLine1
            // 
            this.addressLine1.DataPropertyName = "addressLine1";
            this.addressLine1.HeaderText = "Address Line 1";
            this.addressLine1.Name = "addressLine1";
            this.addressLine1.ReadOnly = true;
            this.addressLine1.Width = 110;
            // 
            // addressLine2
            // 
            this.addressLine2.DataPropertyName = "addressLine2";
            this.addressLine2.HeaderText = "Address Line 2";
            this.addressLine2.Name = "addressLine2";
            this.addressLine2.ReadOnly = true;
            this.addressLine2.Width = 110;
            // 
            // addressLine3
            // 
            this.addressLine3.DataPropertyName = "addressLine3";
            this.addressLine3.HeaderText = "Address Line 3";
            this.addressLine3.Name = "addressLine3";
            this.addressLine3.ReadOnly = true;
            this.addressLine3.Width = 110;
            // 
            // addressTypeID
            // 
            this.addressTypeID.DataPropertyName = "addressTypeID";
            this.addressTypeID.HeaderText = "addressTypeID";
            this.addressTypeID.Name = "addressTypeID";
            this.addressTypeID.ReadOnly = true;
            this.addressTypeID.Visible = false;
            this.addressTypeID.Width = 133;
            // 
            // addressTypeDescription
            // 
            this.addressTypeDescription.DataPropertyName = "addressTypeDescription";
            this.addressTypeDescription.HeaderText = "Address Type";
            this.addressTypeDescription.Name = "addressTypeDescription";
            this.addressTypeDescription.ReadOnly = true;
            this.addressTypeDescription.Width = 115;
            // 
            // city
            // 
            this.city.DataPropertyName = "city";
            this.city.HeaderText = "City";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            this.city.Width = 60;
            // 
            // suburb
            // 
            this.suburb.DataPropertyName = "suburb";
            this.suburb.HeaderText = "Suburb";
            this.suburb.Name = "suburb";
            this.suburb.ReadOnly = true;
            this.suburb.Width = 83;
            // 
            // postalCode
            // 
            this.postalCode.DataPropertyName = "postalCode";
            this.postalCode.HeaderText = "Postal Code";
            this.postalCode.Name = "postalCode";
            this.postalCode.ReadOnly = true;
            this.postalCode.Width = 104;
            // 
            // emailAddress
            // 
            this.emailAddress.DataPropertyName = "emailAddress";
            this.emailAddress.HeaderText = "Email";
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.ReadOnly = true;
            this.emailAddress.Width = 71;
            // 
            // emailTypeID
            // 
            this.emailTypeID.DataPropertyName = "emailTypeID";
            this.emailTypeID.HeaderText = "emailTypeID";
            this.emailTypeID.Name = "emailTypeID";
            this.emailTypeID.ReadOnly = true;
            this.emailTypeID.Visible = false;
            this.emailTypeID.Width = 115;
            // 
            // emailTypeDescription
            // 
            this.emailTypeDescription.DataPropertyName = "emailTypeDescription";
            this.emailTypeDescription.HeaderText = "Email Type";
            this.emailTypeDescription.Name = "emailTypeDescription";
            this.emailTypeDescription.ReadOnly = true;
            this.emailTypeDescription.Width = 99;
            // 
            // telephoneNumber
            // 
            this.telephoneNumber.DataPropertyName = "telephoneNumber";
            this.telephoneNumber.HeaderText = "Tel. No.";
            this.telephoneNumber.Name = "telephoneNumber";
            this.telephoneNumber.ReadOnly = true;
            this.telephoneNumber.Width = 61;
            // 
            // telephoneNumberTypeID
            // 
            this.telephoneNumberTypeID.DataPropertyName = "telephoneNumberTypeID";
            this.telephoneNumberTypeID.HeaderText = "telephoneNumberTypeID";
            this.telephoneNumberTypeID.Name = "telephoneNumberTypeID";
            this.telephoneNumberTypeID.ReadOnly = true;
            this.telephoneNumberTypeID.Visible = false;
            this.telephoneNumberTypeID.Width = 195;
            // 
            // telephoneNumberTypeDescription
            // 
            this.telephoneNumberTypeDescription.DataPropertyName = "telephoneNumberTypeDescription";
            this.telephoneNumberTypeDescription.HeaderText = "Tel. No. Type";
            this.telephoneNumberTypeDescription.Name = "telephoneNumberTypeDescription";
            this.telephoneNumberTypeDescription.ReadOnly = true;
            this.telephoneNumberTypeDescription.Width = 113;
            // 
            // pledgeAmount
            // 
            this.pledgeAmount.DataPropertyName = "pledgeAmount";
            this.pledgeAmount.HeaderText = "Pledge Amount";
            this.pledgeAmount.Name = "pledgeAmount";
            this.pledgeAmount.ReadOnly = true;
            this.pledgeAmount.Width = 122;
            // 
            // pledgeTypeID
            // 
            this.pledgeTypeID.DataPropertyName = "pledgeTypeID";
            this.pledgeTypeID.HeaderText = "pledgeTypeID";
            this.pledgeTypeID.Name = "pledgeTypeID";
            this.pledgeTypeID.ReadOnly = true;
            this.pledgeTypeID.Visible = false;
            this.pledgeTypeID.Width = 125;
            // 
            // frmParishPersonsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 455);
            this.Controls.Add(this.cmbSearchCriteria);
            this.Controls.Add(this.dtpSearchCriteria);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtSearchCriteria);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.grd);
            this.Name = "frmParishPersonsView";
            this.Text = "Search Persons";
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.TextBox txtSearchCriteria;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpSearchCriteria;
        private System.Windows.Forms.ComboBox cmbSearchCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn personID;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn personTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn personType;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn maritalStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn maritalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn parishID;
        private System.Windows.Forms.DataGridViewTextBoxColumn parishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn joinedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBaptised;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateConfirmed;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn pledgeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn pledgeTypeID;
    }
}