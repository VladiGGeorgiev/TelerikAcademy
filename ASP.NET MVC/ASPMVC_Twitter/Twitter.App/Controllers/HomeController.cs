using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace Twitter.App.Controllers
{
    public class HomeController : Controller
    {

        private IUnitOfWork db;

        public HomeController() : this(new UnitOfWork())
        {
        }

        public HomeController(IUnitOfWork db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var tweets = db.Tweets.All().ToList();

            return View(tweets);
        }
    }
}