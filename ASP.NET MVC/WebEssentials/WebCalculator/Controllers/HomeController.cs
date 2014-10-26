using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebCalculator.Models;
using WebCalculator.ViewModel;
using Unit = WebCalculator.Models.Unit;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(CalculatorViewModel model)
        {
            if (string.IsNullOrEmpty(model.Type))
            {
                model.Type = "Megabyte";
                model.Quantity = 1m;
                model.Kilo = 1024;
            }

            model.CalculatedUnits = Unit.CalculateUnits(model);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}