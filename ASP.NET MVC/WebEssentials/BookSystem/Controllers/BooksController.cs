using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookSystem.Models;
using System.Data.Entity;

namespace BookSystem.Controllers
{
    public class BooksController : Controller
    {
        
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var books = context.Books.Include(b => b.Category).ToList();
            return View(books);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var context = new ApplicationDbContext();
            var book = context.Books.FirstOrDefault(b => b.BookId == id);

            BookModel model = new BookModel()
            {
                BookId = book.BookId - 1,
                Author = book.Author,
                CategoryId = book.Category.CategoryId,
                Description = book.Description,
                ISBN = book.ISBN,
                Title = book.Title,
                WebSite = book.WebSite
            };

            var categories = context.Categories.ToList();
            model.DropDownItems = categories.Select(category => new SelectListItem()
            {
                Value = category.CategoryId.ToString(), Text = category.Title
            }).ToList();
            

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, BookModel model)
        {
            var context = new ApplicationDbContext();
            var book = context.Books.Find(id);

            book.Author = model.Author;
            book.Description = model.Description;
            book.ISBN = model.ISBN;
            book.Title = model.Title;
            book.WebSite = model.WebSite;

            Category category = context.Categories.FirstOrDefault(c => c.CategoryId == model.CategoryId);
            book.Category = category;

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var context = new ApplicationDbContext();
            var book = context.Books.Include(x => x.Category).FirstOrDefault(x => x.BookId == id);
            return View(book);
        }
        
        [Authorize]
        public ActionResult Delete(int id)
        {
            var context = new ApplicationDbContext();
            var book = context.Books.FirstOrDefault(b => b.BookId == id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}