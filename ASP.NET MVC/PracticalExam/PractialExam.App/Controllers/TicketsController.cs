using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using PractialExam.App.ViewModels;
using PracticalExam.Models;
using PractialExam.App.Models;

namespace PractialExam.App.Controllers
{
    public class TicketsController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(GetTickets());
        }
        
        public ActionResult TicketsRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTickets().ToDataSourceResult(request));
        }

        public ActionResult Details(int id)
        {
            var ticket = this.Db.Tickets.GetById(id);
            var ticketModel = new TicketDetailsViewModel()
            {
                Title = ticket.Title,
                Id = ticket.Id,
                Author = ticket.Author.UserName,
                Category = ticket.Category.Name,
                Description = ticket.Description,
                Priority = ticket.Priority.ToString(),
                ScreenshotUrl = ticket.ScreenshotUrl,
                Comments = ticket.Comments.Select(comment => new CommentViewModel()
                {
                    Author = comment.Author.UserName,
                    Content = comment.Content
                }).ToList()
            };

            return View(ticketModel);
        }

        [Authorize]
        [HttpGet]
        [ActionName("Add")]
        public ActionResult DisplayAddTicketPage()
        {
            ViewBag.Categories = this.Db.Categories.All().Select(x => new {Name = x.Name, Id = x.Id});
            ViewBag.Priorities = Enum.GetNames(typeof (Priority));
            return View();
        }

        [Authorize]
        [HttpPost]
        [ActionName("Add")]
        public ActionResult AddTicket(AddTicketModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var ticket = new Ticket()
                {
                    AuthorId = userId,
                    CategoryId = model.Category,
                    Title = model.Title,
                    Priority = ConvertStringToPriority(model.Priority),
                    Description = model.Description,
                    ScreenshotUrl = model.ScreenshotUrl
                };

                this.Db.Tickets.Add(ticket);
                var user = this.Db.Users.All().FirstOrDefault(u => u.Id == userId);
                user.Points += 1;
                this.Db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = this.Db.Categories.All().Select(x => new { Name = x.Name, Id = x.Id });
            ViewBag.Priorities = Enum.GetNames(typeof(Priority));
            return View();
        }

        [Authorize]
        [HttpPost]
        [ActionName("Comment")]
        public ActionResult Comment(CommentModel model)
        {
            var comment = new Comment()
            {
                AuthorId = this.User.Identity.GetUserId(),
                TicketId = model.TicketId,
                Content = model.Content
            };
            this.Db.Comments.Add(comment);
            this.Db.SaveChanges();

            var commentViewModel = new CommentViewModel()
            {
                Author = this.User.Identity.Name,
                Content = model.Content
            };

            return PartialView("_CommentPartial", commentViewModel);
        }

        [Authorize]
        public ActionResult Search(int? search)
        {
            if (search != null)
            {
                var tickets = this.Db.Tickets.All().Where(x => x.CategoryId == search)
                        .Select(t => new TicketViewModel()
                        {
                            Id = t.Id,
                            AuthorName = t.Author.UserName,
                            CategoryName = t.Category.Name,
                            CommentsNumber = t.Comments.Count,
                            Title = t.Title
                        });

                ViewBag.Category = this.Db.Categories.GetById(search.Value).Name;
                return View(tickets);
            }
            else
            {
                var tickets = this.Db.Tickets.All()
                        .Select(t => new TicketViewModel()
                        {
                            Id = t.Id,
                            AuthorName = t.Author.UserName,
                            CategoryName = t.Category.Name,
                            CommentsNumber = t.Comments.Count,
                            Title = t.Title
                        });
                return View(tickets);
            }
        }

        [Authorize]
        public ActionResult GetCategories()
        {
            var categories = this.Db.Categories.All()
                .Select(x => new { CategoryName = x.Name, CategoryId = x.Id });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<TicketListViewModel> GetTickets()
        {
            var tickets = this.Db.Tickets.All()
                .Select(ticket => new TicketListViewModel()
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    CategoryName = ticket.Category.Name,
                    AuthorName = ticket.Author.UserName,
                    PriorityType = ticket.Priority
                });
            return tickets;
        }
        
        private Priority ConvertStringToPriority(string model)
        {
            var priority = model.ToLower();
            switch (priority)
            {
                case "high":
                    return Priority.High;
                case "low":
                    return Priority.Low;
                case "medium":
                    return Priority.Medium;
                default: throw new ArgumentException("Invalid priority!");
            }
        }
    }
}