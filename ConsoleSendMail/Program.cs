using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string fromMail = ""; // 发送者邮箱
            string toMail = ""; // 接收者邮箱
            string fromMailPass = ""; // 发送者邮箱密码或授权码

            string mailSubject = "ceshi";
            string mailContent = "ceshi";

            p.SendMail(fromMail, toMail, fromMailPass, mailSubject, mailContent);
        }

        public void SendMail(string fromMail,string toMail,string fromMailPass,string mailSubject,string mailContent)
        {
            Console.WriteLine("send start");
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.exmail.qq.com";  // QQ邮箱用smtp.qq.com，QQ企业邮箱用smtp.exmail.qq.com
            client.Port = 587; // QQ邮箱或QQ企业邮箱用465报错，用587发送成功
            client.Credentials = new NetworkCredential(fromMail, fromMailPass);

            MailMessage mailMsg = new MailMessage(fromMail, toMail, mailSubject, mailContent);
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.IsBodyHtml = true;

            try
            {
                client.Send(mailMsg);
                Console.WriteLine("send success");
                Console.ReadKey();
            }
            catch(SmtpException e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }

        }
    }
}
