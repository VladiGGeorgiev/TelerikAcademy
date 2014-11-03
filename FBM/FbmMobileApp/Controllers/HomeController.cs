using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FbmMobileApp.Data;
using FbmMobileApp.Models;

namespace FbmMobileApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new FbmContext();
            context.Towns.Add(new Town() {Name = "Sofia"});
            context.SaveChanges();
            return View();
        }
    }
}
