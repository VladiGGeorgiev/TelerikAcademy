using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using LaptopSystem.App.ViewModels;

namespace LaptopSystem.App.Controllers
{
    public class HomeController : BaseController
    {
        private const string LaptopsCacheName = "HomePageLaptops";

        public ActionResult Index()
        {
            if (this.HttpContext.Cache[LaptopsCacheName] == null)
            {
                var laptops = this.Db.LaptopsRepository.All()
                    .OrderBy(x => x.Model)
                    .Take(6).Select(x => new LaptopViewModel()
                    {
                        Id = x.Id,
                        ImageUrl = x.ImageUrl,
                        Model = x.Model,
                        Price = x.Price,
                        Manufacturer = x.Manufacturer.Name
                    }).ToList();

                this.HttpContext.Cache.Add(LaptopsCacheName, laptops, null, DateTime.Now.AddHours(1), TimeSpan.Zero,
                    CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache[LaptopsCacheName]);
        }
    }
}