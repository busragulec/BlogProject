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
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox(int id, int writerId)
        {
            Context c = new Context();
            ViewBag.i = id;
            //int id = 2;
            var values = mm.GetInboxListByWriter(id);
            ViewBag.Username = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterName;
            ViewBag.image = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterImage;
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }
    }
}