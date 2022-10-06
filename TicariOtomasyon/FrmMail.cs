using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace TicariOtomasyon
{
    
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string Mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            textBox1.Text = Mail;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MailMessage send = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("MAILIM","SİFRE");
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
                send.To.Add(richTextBox1.Text);
            send.From = new MailAddress("MAIL");
            send.Subject = textBox2.Text;
            send.Body = richTextBox1.Text;
            istemci.Send(send);
        }
    }
}
