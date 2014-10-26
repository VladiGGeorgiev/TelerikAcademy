using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PractialExam.App.Controllers;
using PractialExam.App.ViewModels;
using PracticalExam.Models;
using PracticalExam.Data;

namespace PractialExam.App.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCategoriesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Administration/AdminCategories/
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var comments = this.Db.Categories.All()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Json(comments.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.Db.Categories.Add(new Category()
                {
                    Name = category.Name
                });
                this.Db.SaveChanges();
            }

            return Json(new[] {category}.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null)
            {
                var dbCategory = this.Db.Categories.GetById(category.Id);
                var tickets = dbCategory.Tickets.ToList();
                foreach (var ticket in tickets)
                {
                    this.Db.Tickets.Delete(ticket);
                }

                this.Db.Categories.Delete(dbCategory);
                this.Db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var category = this.Db.Categories.GetById(model.Id);
                category.Name = model.Name;
                this.Db.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
