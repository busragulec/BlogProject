using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification(int writerId)
        {
            Context c = new Context();
            var values = nm.GetList();
            ViewBag.Username = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterName;
            ViewBag.image = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterImage;
            return View(values);
        }
    }
}