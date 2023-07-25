using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructure.dl
{
  public  interface IRepository
    {
        List<string> GetAllSubject();
        int Add(Email email);
        List<Email> GetEmails();
        Email GetById(int id);


    }
}
