using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using Shawoo.Common;
namespace FEPV.Implementation
{
    public class HelperBiz
    {
        public string SendMail(string emails,string subject,string body)
        {
            //Step3 发送邮件 ======================
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("FEPVMES@feg.cn", "FEPVMES系统邮件");
           
                string[] strMailNames = emails.Split(';');
                foreach (string strMailName in strMailNames)
                {
                    mailMessage.To.Add(new MailAddress(strMailName));
                }

                mailMessage.Subject = subject;
                mailMessage.Body = body;

            mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");
            string email_Server = "email.feg.cn";
          //  string sAttach = repfilename;

            //if (sAttach != "")
            //{
            //    char[] delim = new char[] { ',' };
            //    foreach (string sSubstr in sAttach.Split(delim))
            //    {
            //        System.Net.Mail.Attachment MyAttachment = new System.Net.Mail.Attachment(sSubstr);
            //        mailMessage.Attachments.Add(MyAttachment);
            //    }
            //}

            SmtpClient client = new SmtpClient(email_Server);
            try
            {
                client.Send(mailMessage);
                return "";
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
                return "发送邮件异常"+ex.Message+ex.StackTrace;
            }
        }

    }
}
