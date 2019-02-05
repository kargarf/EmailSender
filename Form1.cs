
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try 
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                MailMessage message = new MailMessage(); 

                message.From = new MailAddress("youremail@gmail.com"); // Sending Email
                message.To.Add(txtreciever.Text); // To emailid
                message.Subject = txtsubject.Text; // Subject
                message.Body = txtbody.Text; // Body
                
                client.UseDefaultCredentials = false; 
                client.EnableSsl = true; // Enabling secured Connection
                client.Credentials = new System.Net.NetworkCredential("youremail@gmail.com", "yourPassword"); // Credential of gmail

                Cursor.Current = Cursors.WaitCursor;
                client.Send(message); //Sending...

                MessageBox.Show("Email Sent Successfully.");
                Cursor.Current = Cursors.Default;
                message = null; // Free the memory
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
