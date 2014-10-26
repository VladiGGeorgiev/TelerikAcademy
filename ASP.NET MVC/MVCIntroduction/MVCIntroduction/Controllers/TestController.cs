using MVCIntroduction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIntroduction.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [ActionName("GetHumans")]
        public ActionResult Index()
        {
            var humans = new List<Human>() {
                new Human() { Name="Minka Svirkata", Age=18 },
                new Human() { Name="Penka Duduka", Age=28 },
                new Human() { Name="Jivka Trybata", Age=38 },
                new Human() { Name="Didi Moshnata", Age=48 },
                new Human() { Name="Stanka Bastuna", Age=58 },
            };

            return View(humans);
        }
	}
}