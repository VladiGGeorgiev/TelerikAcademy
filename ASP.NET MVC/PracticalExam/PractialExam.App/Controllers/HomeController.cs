using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using PractialExam.App.ViewModels;

namespace PractialExam.App.Controllers
{
    public class HomeController : BaseController
    {
        private const string TicketsCacheName = "HomePageTickets";

        public ActionResult Index()
        {
            if (this.HttpContext.Cache[TicketsCacheName] == null)
            {
                var tickets = this.Db.Tickets.All()
                    .OrderByDescending(ticket => ticket.Comments.Count)
                    .Take(6)
                    .Select(t => new TicketViewModel()
                    {
                        Id = t.Id,
                        AuthorName = t.Author.UserName,
                        CategoryName = t.Category.Name,
                        CommentsNumber = t.Comments.Count,
                        Title = t.Title
                    }).ToList();

                this.HttpContext.Cache.Add(TicketsCacheName, tickets, null, DateTime.Now.AddHours(1), TimeSpan.Zero,
                CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache[TicketsCacheName]);
        }
    }
}