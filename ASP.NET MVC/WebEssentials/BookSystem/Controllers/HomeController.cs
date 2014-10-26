using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSystem.Models;

namespace BookSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var categories = context.Categories.Include(x => x.Books).ToList();

            return View(categories);
        }
    }
}