using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}