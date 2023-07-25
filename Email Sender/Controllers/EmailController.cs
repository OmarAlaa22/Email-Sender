using Domain.Entity;
using Email_Sender.ViewModel;
using Infarstructure.dl;
using Infarstructure.Services;
using Infarstructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Sender.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmail_Service _Service;
        //ToastrNotification
        private readonly IToastNotification _toastNotification;
        public EmailController(IEmail_Service Service, IToastNotification toastNotification)
        {
            _Service = Service;
            _toastNotification = toastNotification;
         
        }
        public IActionResult Index()
        {
            //return list of subject
            ViewBag.subjects = _Service.ShowEmailSubject();
            return View();
        }

         [HttpPost]
        public IActionResult SaveEmail(EmailViewModel viewmodel)
        {
            List<string> subject = _Service.ShowEmailSubject();

            if (ModelState.IsValid)
            {
                _Service.SaveEmail(viewmodel);
                //pass list of subject to index 
                ViewBag.subjects = subject;
                _toastNotification.AddSuccessToastMessage("Email Added");

                return RedirectToAction("Index");
            }
            ViewBag.subjects = subject;
            return View("index", viewmodel);
        }


        public IActionResult EmailList()
        {
            //return Email List in EmailList view
            ViewBag.Emails = _Service.GetAllEmail();
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailAddress addresses)
        {

          if(  _Service.SendEmail(addresses))
            {
                _toastNotification.AddSuccessToastMessage("message Sent");

                return RedirectToAction("EmailList");
            }
            return  RedirectToAction("EmailList");
        }

    }
}
