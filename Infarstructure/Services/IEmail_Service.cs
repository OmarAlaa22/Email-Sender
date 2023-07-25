using Domain.Entity;
using Email_Sender.ViewModel;
using Infarstructure.ViewModel;
using System.Collections.Generic;

namespace Infarstructure.Services
{
    public interface IEmail_Service
    {
        List<Email> GetAllEmail();
        bool SaveEmail(EmailViewModel emailviewmodel);
        bool SendEmail(EmailAddress addresses);
        List<string> ShowEmailSubject();
    }
}