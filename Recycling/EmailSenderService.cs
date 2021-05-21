using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace Recycling
{
    public class EmailSenderService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("河马回收平台", "424539340@qq.com");
            message.From.Add(from);
            var to = new MailboxAddress("", email);
            message.To.Add(to);
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder {HtmlBody = htmlMessage};
            message.Body = bodyBuilder.ToMessageBody();
            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.qq.com", 587, false);

            await client.AuthenticateAsync("424539340@qq.com", "qjxgznjoasjebjej"); // 改成自己QQ邮箱的。

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            Console.Write("邮件发送OK");
        }
    }
}