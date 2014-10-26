using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSystem.Models;

namespace BookSystem.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var categories = context.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var context = new ApplicationDbContext();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryModel model)
        {
            var context = new ApplicationDbContext();
            var category = context.Categories.Single(x => x.CategoryId == id); //.FirstOrDefault(c => c.CategoryId == id);
            TryUpdateModel(category);
            return RedirectToAction("Index");


//
//            category.Title = model.Title;
            //context.SaveChanges();

        }

        public ActionResult Delete(int id)
        {
            var context = new ApplicationDbContext();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);


            context.Books.RemoveRange(category.Books);
            foreach (var book in category.Books)
            {
                context.Books.Remove(book);
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

	}
}