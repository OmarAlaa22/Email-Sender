using Domain.Entity;
using Infarstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructure.dl
{
    public class Repository : IRepository
    {
        private readonly EmailSenderDbContex _Context;
        public Repository(EmailSenderDbContex Context)
        {
            _Context = Context;
        }

        public int Add(Email email)
        {
            //add email
            _Context.Emails.Add(email);
          return  _Context.SaveChanges();
        }

        public List<string> GetAllSubject()
        {
            // get "only" subject
            return _Context.Emails.Select(x => x.Subject).ToList();
        }

        public Email GetById(int id)
        {
            //get email content by id
            return _Context.Emails.FirstOrDefault(x => x.Id == id);
        }

        public List<Email> GetEmails()
        {
            //get list of emails
           return _Context.Emails.ToList();
        }
    }
}
