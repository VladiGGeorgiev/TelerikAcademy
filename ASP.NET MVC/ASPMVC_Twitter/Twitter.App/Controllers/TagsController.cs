using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace Twitter.App.Controllers
{
    public class TagsController : Controller
    {
        private IUnitOfWork db;

        public TagsController(IUnitOfWork db)
        {
            this.db = db;
        }

        public TagsController() : this(new UnitOfWork())
        {
        }

        [OutputCache(Duration = 900)]
        public ActionResult Index(string tag)
        {
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Home");
            }

            var model = db.HashTags.All().FirstOrDefault(x => x.Name == tag);

            return View(model);
        }
    }
}