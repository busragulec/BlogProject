using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            nm.AddNewsLetter(p);
            return PartialView();
        }
    }
}