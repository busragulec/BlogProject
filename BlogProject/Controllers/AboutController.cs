using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}