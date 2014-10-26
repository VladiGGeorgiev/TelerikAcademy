using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using KendoUI_LibrarySystem.Models;
using System.Data.Entity;

namespace KendoUI_LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var categories = context.Categories
                .Include(x => x.Books)
                .ToList().Select(z => new TreeViewItemModel()
                {
                    Text = z.Title,
                    Items = z.Books.AsQueryable().Select(b => new TreeViewItemModel()
                    {
                        Text = string.Format("{0} ({1})", b.Title, b.Author),
                        Url = "/Books/Details/" + b.BookId
                    }).ToList()
                });

            var books = context.Books.ToList();
            var bookTitles = books.Select(book => book.Title).ToList();
            bookTitles.AddRange(books.Select(book => book.Author));

            ViewBag.BookTitles = bookTitles;

            return View(categories);
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