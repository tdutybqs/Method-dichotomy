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

namespace MenuItem
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int port = 587; // порт smtp сервера, в данном случае выбран яндекс
            bool enableSSL = true;

            string emailFrom = ""; // адрес почты отправителя письма
            string password = ""; // пароль почты отправителя письма
            string emailTo = textBox1.Text; ; // адрес почты получателя письма
            string subject = textBox2.Text; // тема письма
            string body = textBox3.Text; // текст письма
            string smtpAddress = "smtp.yandex.ru"; // адрес stmp сервера

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true; // можно поставить false, если отправляется только текст

            if (sendAtt)
            {
                mail.Attachments.Add(new Attachment(filename));
            }

            using (SmtpClient smtp = new SmtpClient(smtpAddress, port))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                try
                {
                    smtp.Send(mail); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString()); 
                }
            }

        }

        public string filename;

        public bool sendAtt=false;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            sendAtt = true;
        }

        private void ChangeNames()
        {
            this.Text = Form1.Use[50];
            this.To.Text = Form1.Use[46];
            this.Title.Text = Form1.Use[49];
            this.button2.Text= Form1.Use[47];
            this.button1.Text = Form1.Use[48];
        }

        private void SendEmail_Load(object sender, EventArgs e)
        {
            this.BackColor = Form1.bColor;
            this.To.ForeColor = Form1.ColorText;
            this.Title.ForeColor = Form1.ColorText;
            if (!Form1.language)
            {
                ChangeNames();
            }
        }
    }
}
