using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BlogProject.Controllers
{
    public class LoginConroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}