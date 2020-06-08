using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mvc_template.Helpers
{
    public class SMTPEmailSender
    {
        SmtpClient client;
        //public log4net.ILog logger;
        Queue<MailMessage> _messages = new Queue<MailMessage>();

        public SMTPEmailSender()
        {
            //Init Logger
            //logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            client = new SmtpClient();
        }

        public void SendInvitationEmail(string from, string to, string subject, string body, bool isBodyHtml)
        {
            MailMessage msg = new MailMessage();
            msg.Body = "<div style='direction:rtl;'>" + body.Replace("&lt;", "<").Replace("&gt;", ">") + "<p><strong>مع وافر الاحترام والتقدير</strong></p></div>";
            msg.Subject = subject;
            msg.From = new MailAddress(from);
            msg.To.Add(to);             

            msg.IsBodyHtml = isBodyHtml;
            //client.EnableSsl = true;
         //   msg.CC.Add(new MailAddress("ahashish@it-blocks.com"));

            Object state = to;

            lock (_messages)
            {
                _messages.Enqueue(msg);
                if (_messages.Count == 1)
                {
                    ThreadPool.QueueUserWorkItem(SendEmailInternal);
                }
            }          
        }
        protected virtual void SendEmailInternal(object state)
        {
            while (true)
            {
                MailMessage msg;
                lock (_messages)
                {
                    if (_messages.Count == 0)
                        return;
                    msg = _messages.Dequeue();
                    try
                    {
                        client.Send(msg);

                       // logger.Info("Mail sent successfully to " + msg.To.ToString());
                    }
                    catch (Exception ex)
                    {
                        //logger.Error("Mail send failure to " + msg.To.ToString()+"::"+ex.Message+"::"+ex.StackTrace);
                    }
                }
            }
        }

        public bool SendEmail(string from, string to, string subject, string body, bool isBodyHtml)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = subject;
                msg.From = new MailAddress(from);
                msg.To.Add(to);
                msg.Body = body;
                msg.IsBodyHtml = isBodyHtml;
               // client.EnableSsl = true;
              //  msg.CC.Add(new MailAddress("ahashish@it-blocks.com"));
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message);
                return false;
            }
        }
        public bool SendEmail(string from, string to, string cc, string bcc, string subject, string body, bool isBodyHtml)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            ConvertFromSemiColonSeparatedEmailsToMailAddressCollection(msg.To, to);
            ConvertFromSemiColonSeparatedEmailsToMailAddressCollection(msg.Bcc, bcc);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = isBodyHtml;
            try
            {
                client.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void ConvertFromSemiColonSeparatedEmailsToMailAddressCollection(MailAddressCollection emailsCollection, string emails)
        {
            if (emails == null) return;

            string[] emailsSeparated = emails.Split(',', ';');

            foreach (var email in emailsSeparated)
            {
                if (!string.IsNullOrWhiteSpace(email))
                    emailsCollection.Add(new MailAddress(email.Trim()));
            }
        }
    }
}
