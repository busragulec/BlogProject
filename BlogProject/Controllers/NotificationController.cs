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
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification(int writerId)
        {
            Context c = new Context();
            var values = nm.GetList();
            //ViewBag.Username = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterName;
            //ViewBag.image = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterImage;

            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var valuess = bm.GetListWithCategoryByWriterBm(writerID);

            ViewBag.Username = c.Blogs.Join(c.Writers,
                blogsPoint => blogsPoint.WriterID,
                writerPoint => writerPoint.WriterID,
                (blogsPoint, writerPoint) => new { blogsPoint, writerPoint }
                ).Where(y => y.blogsPoint.WriterID == writerID).FirstOrDefault().writerPoint.WriterName;

            ViewBag.image = c.Blogs.Join(c.Writers,
                 blogsPoint => blogsPoint.WriterID,
                 writerPoint => writerPoint.WriterID,
                 (blogsPoint, writerPoint) => new { blogsPoint, writerPoint }
                 ).Where(y => y.blogsPoint.WriterID == writerID).FirstOrDefault().writerPoint.WriterImage;

            return View(values);
        }
    }
}