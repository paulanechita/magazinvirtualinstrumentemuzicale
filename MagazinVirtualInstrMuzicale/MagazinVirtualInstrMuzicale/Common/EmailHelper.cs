using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Common
{
    public static class EmailHelper
    {
        public static void SendEmail(string emailFrom, string emailTo, string name, string subject, string message)
        {

            string EmailUsedForSMTP = Constants.EmailUsedForSMTP;
            string Password = Constants.Password;
            
            MailAddress mailFrom = new MailAddress(emailFrom, name);
            MailAddress mailTo = new MailAddress(emailTo);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                //change the port to prt 587. This seems to be the standard for Google smtp transmissions.
                Port = 587,
                //enable SSL to be true, otherwise it will get kicked back by the Google server.
                EnableSsl = true,
                //The following properties need set as well
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailUsedForSMTP, Password)
            };

            using (MailMessage mail = new MailMessage(mailFrom, mailTo)
            {
                Subject = subject,
                Body = message

            })

                smtp.Send(mail);
        }
    }
}