using Domain.Entity;
using Email_Sender.ViewModel;
using Infarstructure.dl;
using Infarstructure.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructure.Services
{
    public class Email_Service : IEmail_Service
    {
        private readonly IRepository _Repo;
        private readonly IConfiguration _configuration;
        public Email_Service(IRepository Repo, IConfiguration configuration)
        {
            _Repo = Repo;
            _configuration = configuration;
        }
        public List<string> ShowEmailSubject()
        {
            return _Repo.GetAllSubject();
        }
        public bool SaveEmail(EmailViewModel emailviewmodel)
        {
            var email = new Email();
            email.Message = emailviewmodel.message;
            email.Subject = emailviewmodel.subject;
            if (_Repo.Add(email) > 0)
            {
                return true;
            }
            return false;
        }
        public List<Email> GetAllEmail()
        {
            return _Repo.GetEmails();

        }

        public bool SendEmail(EmailAddress addresses)
        {
            Email EmailContent = _Repo.GetById(addresses.SubjectMailId);

            if (!string.IsNullOrEmpty(addresses.Email))
            {
                var emailinfo = GetSendEmailConnectionInfo();
                // split Emails by , 
                foreach (var item in addresses.Email.Split(','))
                {
                    //Add message content and detrmine source and destination
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Email Sender System", emailinfo.EmailAdress));
                    message.To.Add(new MailboxAddress("Aman", item));
                    message.Subject = EmailContent.Subject;
                    message.Body = new TextPart() { Text = EmailContent.Message };

                    using (var client = new SmtpClient())
                    {
                        client.Connect(emailinfo.host, emailinfo.PortId);
                        // Note: since we don't have an OAuth2 token, disable
                        // the XOAUTH2 authentication mechanism.
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate(emailinfo.EmailAdress, emailinfo.Password);
                        client.Send(message);

                        client.Disconnect(true);
                    }

                }
                return true;

            }

            return false;
        }
        private (int PortId, string EmailAdress, string Password, string host) GetSendEmailConnectionInfo()
        {
            var EmailInfo = _configuration.GetSection("Emailinfo");
            var port = int.Parse(EmailInfo["Port"]);
            var Email = EmailInfo["Email"];
            var password = EmailInfo["password"];
            var host = EmailInfo["Host"];
            return (port, Email, password, host);

        }
    }

}
