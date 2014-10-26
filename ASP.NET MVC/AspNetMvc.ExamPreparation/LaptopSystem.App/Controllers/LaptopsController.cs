using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LaptopSystem.App.Models;
using LaptopSystem.App.ViewModels;
using LaptopSystem.Models;
using Microsoft.AspNet.Identity;

namespace LaptopSystem.App.Controllers
{
    public class LaptopsController : BaseController
    {
        public ActionResult Index()
        {
            var laptops = this.Db.LaptopsRepository.All().Select(x => new LaptopViewModel()
            {
                Id = x.Id,
                Model = x.Model,
                Manufacturer = x.Manufacturer.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToList();

            return View(laptops);
        }

        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            var laptops = this.Db.LaptopsRepository.All();
            if (!string.IsNullOrEmpty(model.ManufacturerSearchText))
            {
                laptops =
                    laptops.Where(laptop => laptop.Manufacturer.Name.ToLower().Contains(model.ManufacturerSearchText.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.ModelSearchText))
            {
                laptops = laptops.Where(laptop => laptop.Model.ToLower().Contains(model.ModelSearchText.ToLower()));
            }
            if (!string.IsNullOrEmpty(model.PriceNumeric))
            {
                laptops = laptops.Where(laptop => laptop.Price < decimal.Parse(model.PriceNumeric));
            }

            var laptopsModel = laptops.Select(x => new LaptopViewModel()
            {
                Id = x.Id,
                Model = x.Model,
                ImageUrl = x.ImageUrl,
                Manufacturer = x.Manufacturer.Name,
                Price = x.Price
            });

            return View("Index", laptopsModel);
        }

        public JsonResult SearchAutocompleteModel(string text)
        {
            var laptops = this.Db.LaptopsRepository.All()
                .Where(laptop => laptop.Model.ToLower().Contains(text.ToLower()))
                .Select(x => new 
                {
                    Model = x.Model,
                });

            return Json(laptops, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDropdownManufacturers()
        {
            var manufacturers = this.Db.ManufacturersRepository.All()
                .Select(x => new { Title = x.Name, id= x.Id });

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var laptop = this.Db.LaptopsRepository.GetById(id);
            var viewModel = new LaptopDetailsViewModel()
            {
                AdditionalParts = laptop.AdditionalParts,
                ImageUrl = laptop.ImageUrl,
                Manufacturer = laptop.Manufacturer.Name,
                Model = laptop.Model,
                Price = laptop.Price,
                Id = laptop.Id,
                Comments = laptop.Comments.Select(x => new CommentViewModel()
                {
                    Author = x.Author.UserName,
                    Content = x.Content
                }).ToList(),
                Description = laptop.Description,
                HardDiskSize = laptop.HardDiskSize,
                MonitorSize = laptop.MonitorSize,
                RamMemorySize = laptop.RamMemorySize,
                Weight = laptop.Weight,
                Votes = laptop.Votes.Count(),
                UserCanVote = laptop.Votes.All(vote => vote.VotedById != this.User.Identity.GetUserId()),
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Comment(CommentModel model)
        {
            Comment comment = new Comment()
            {
                AuthorId = User.Identity.GetUserId(),
                LaptopId = model.LaptopId,
                Content = model.Content
            };

            this.Db.CommentsRepository.Add(comment);
            this.Db.SaveChanges();

            var commentViewModel = new CommentViewModel()
            {
                Author = User.Identity.Name,
                Content = comment.Content
            };

            return PartialView("_CommentPartial", commentViewModel);
        }

        [HttpPost]
        public ActionResult Vote(int laptopId)
        {
            var laptop = this.Db.LaptopsRepository.GetById(laptopId);
            var userId = this.User.Identity.GetUserId();

            var canVote = !this.Db.VotesRepository.All().Any(x => x.LaptopId == laptopId && x.VotedById == userId);
            if (canVote)
            {
                laptop.Votes.Add(new Vote()
                {
                    VotedById = userId
                });
                this.Db.SaveChanges();
            }
            return Content(laptop.Votes.Count.ToString());
        }

        public JsonResult GetLaptops([DataSourceRequest] DataSourceRequest request)
        {
            var laptops = this.Db.LaptopsRepository.All()
                .Select(x => new LaptopViewModel()
                {
                    Id = x.Id,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Manufacturer = x.Manufacturer.Name,
                    Price = x.Price
                });

            return Json(laptops.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}