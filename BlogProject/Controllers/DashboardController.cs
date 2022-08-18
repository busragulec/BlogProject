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
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index(int writerId)
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = c.Categories.Count();

            //ViewBag.Username = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterName;

            //ViewBag.image = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterImage;


            //return View();

            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerID);

            if (c.Blogs.Where(x => x.WriterID == writerId).Count() <= 0)
            {
                ViewBag.Username = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterName;
                ViewBag.Image = c.Writers.Where(x => x.WriterID == writerId).FirstOrDefault().WriterImage;
            }
            else
            {
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
            }

            return View(values);
        }
    }
}