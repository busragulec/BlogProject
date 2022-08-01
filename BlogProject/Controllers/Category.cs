using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;


namespace BlogProject.Controllers
{
    public class Category : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public bool CategoryStatus { get; internal set; }

        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}