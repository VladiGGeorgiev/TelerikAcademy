using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KendoUI_LibrarySystem.Models;
using Kendo.Mvc.UI;

namespace KendoUI_LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Books/
        public ActionResult Index()
        {
            var categories = db.Books.Include(x => x.Category).ToList().Select(x => new BookModel()
            {
                Title = x.Title,
                Author = x.Author,
                BookId = x.BookId,
                Category = x.Category.Title,
                Description = x.Description,
                ISBN = x.ISBN,
                WebSite = x.WebSite
            });

            return View(categories);
        }

        // GET: /Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Books/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: /Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, Book book)
        {
            var dbBook = db.Books.FirstOrDefault(x => x.BookId == book.BookId);
            dbBook.Author = book.Author;
            dbBook.Description = book.Description;
            dbBook.ISBN = book.ISBN;
            dbBook.Title = book.Title;
            dbBook.WebSite = book.WebSite;
            db.SaveChanges();
            return RedirectToAction("Index");

            return View(book);
        }

        // GET: /Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteConfirmed([DataSourceRequest] DataSourceRequest request, int bookId)
        {
            Book book = db.Books.Find(bookId);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string query)
        {
            var books = db.Books.Include(x => x.Category)
                .Where(x => x.Title.ToLower().Contains(query.ToLower()) || x.Author.ToLower().Contains(query.ToLower()));
            return View(books);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
