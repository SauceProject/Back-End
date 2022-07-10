using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ITI.Sauce.Services
{
    public class EmailServices
    {
       
            SMTPConfig smptConfig;
            public EmailServices(IOptions<SMTPConfig> _smptConfig)
            {
                smptConfig = _smptConfig.Value;
            }
            public async Task SendEmail(SendEmailOptions options)
            {
                var client = new SmtpClient(smptConfig.Host, smptConfig.Port)
                {
                    Credentials = new NetworkCredential(smptConfig.Username, smptConfig.Password),
                    EnableSsl = true
                };

            MailMessage mail = new MailMessage()
            {
                Body = options.Body,
                From = new MailAddress(options.FromEmail, options.FromEmailDisplayName),
                Subject = options.Subject,
                IsBodyHtml = options.IsBodyHTML
            };
            options.ToEmails.ForEach(i => mail.To.Add(i));
            await client.SendMailAsync(mail);
        }
        
    }
}
