using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="Büşra"
                },
                new UserComment
                {
                    ID=2,
                    Username="Murat"
                },
                new UserComment
                {
                    ID=3,
                    Username="Kübra"
                }
            };
            return View(commentvalues);
        }
    }
}