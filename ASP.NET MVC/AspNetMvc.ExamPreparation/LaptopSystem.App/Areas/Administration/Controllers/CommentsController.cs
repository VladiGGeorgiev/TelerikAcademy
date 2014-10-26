using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LaptopSystem.App.Controllers;
using LaptopSystem.App.Models;
using LaptopSystem.App.ViewModels;

namespace LaptopSystem.App.Areas.Administration.Controllers
{
    public class CommentsController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Administration/Comments/
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var comments = this.Db.CommentsRepository.All()
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    Author = x.Author.UserName,
                    Content = x.Content
                });

            var count = comments.Count();
            return Json(comments.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Administration/Comments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administration/Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administration/Comments/Create
        [HttpPost]
        public ActionResult Create(CommentModel model)
        {

            return null;
        }

        //
        // GET: /Administration/Comments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administration/Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administration/Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
