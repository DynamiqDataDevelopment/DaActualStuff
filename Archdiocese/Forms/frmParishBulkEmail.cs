using Archdiocese.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmParishBulkEmail : Form
    {
        clsParishEmailAddress_List _Data;
        public frmParishBulkEmail()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data = new clsParishEmailAddress_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_Data.Count < 1)
                {
                    MessageBox.Show("No Email addresses have been loaded", "Error retrieving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    Dispose();
                }
            }
        }

        private void SendEmail(clsParishEmailAddress_List emailAddressList)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("noreply@ddbs.co.za");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Host = "smtp.gmail.com";
                client.Host = "webmail.ddbs.co.za";
                mail.To.Add(new MailAddress("jarred.koorbanally@gmail.com"));

                //foreach (clsParishesEmailAddress_Item item in emailAddressList)
                //{
                //    mail.To.Add(item.emailAddress);
                //}
                mail.Subject = txtSubjectLine.Text;
                //client.Credentials = new NetworkCredential("jarred.koorbanally@gmail.com", "P@ssw0rd123");
                //client.Credentials = new NetworkCredential("noreply@ddbs.co.za", "P@ssw0rd123");
                client.Credentials = new NetworkCredential("nadeem.a@ddbs.co.za", "Dynamic1");
                //client.EnableSsl = true;
                mail.Body = txtBody.Text;
  
                client.Send(mail);
                MessageBox.Show(Globals.gsSuccessEmailSending, Globals.gsSuccessCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Globals.gsErrorMessage + ex.Message, "Error sending Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendEmail(_Data);
        }

        private void frmParishBulkEmail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
