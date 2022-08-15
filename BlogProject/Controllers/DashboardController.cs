using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(int writerId)
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}