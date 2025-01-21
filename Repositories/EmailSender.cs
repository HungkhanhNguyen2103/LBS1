using BusinessObject.BaseModel;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace Repositories
{
    public class EmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public async Task<bool> SendEmailAsync(EmailModel emailModel)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));

                if (emailModel.To != null) 
                {
                    foreach (var email in emailModel.To)
                    {
                        emailMessage.To.Add(new MailboxAddress("", email));
                    }
                }
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = emailModel.Body,
                };

                emailMessage.Subject = emailModel.Subject;
                emailMessage.Body = bodyBuilder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
