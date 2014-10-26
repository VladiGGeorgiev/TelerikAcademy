using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspForum.Models;
using AspForum.ViewModel;

namespace AspForum.Controllers
{
    public class HomeController : Controller
    {
        ForumDb db = new ForumDb();

        public ActionResult Index()
        {
            var latestForumPosts = db.ForumPosts
                .OrderByDescending(x => x.CreationTime)
                .Take(10)
                .Select(x => new ForumPostViewModel 
                { 
                    ID = x.ID,
                    Title = x.Title,
                    CreationTime = x.CreationTime,
                    AuthorUsername = x.Author.UserName,
                });

            return View(latestForumPosts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
