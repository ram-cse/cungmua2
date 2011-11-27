using System;
using System.Net.Configuration;
using System.Configuration;
//using System.Web.Mail;
using System.Net.Mail;
using System.IO;

namespace ThichThiMua
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static String FormAddress
        {
            get
            {
                SmtpSection cfg = (SmtpSection)ConfigurationManager.GetSection
                    ("system.net/mailSettings/smtp");
                return cfg.Network.UserName;
            }
        }


        public string SendMail(string subject, string body, string to, bool isHtml, bool isSSL)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(FormAddress, "VI-VN.COM");
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = isHtml;
                    SmtpClient client = new SmtpClient();
                    client.EnableSsl = isSSL;
                    client.Send(mail);
                }
            }
            catch (SmtpException ex)
            {
                return ex.Message;
            }
            return "Send email successful!";
        }


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            CaptchaControl1.ValidateCaptcha(TextBoxCaptcha.Text.Trim());
            if (CaptchaControl1.UserValidated)
            {
                Label1.Visible = true;
                Label1.Text = "You are human...";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Captcha is invalid, Please try again...";
            }

            StreamReader sr = new StreamReader(Server.MapPath("template/Contact.htm"));
            sr = File.OpenText(Server.MapPath("template/Contact.htm"));
            string content = sr.ReadToEnd();
            content = content.Replace("[Sender]", TextBoxFirstName.Text.Trim() + TextBoxLastName.Text.Trim());
            content = content.Replace("[Email]", TextBoxEmail.Text);
            content = content.Replace("[DateTime]", DateTime.Now.ToShortDateString());
            try
            {
                Response.Write(SendMail("Liên hệ khách hàng",
                    content, TextBoxEmail.Text.Trim(), true, false));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}