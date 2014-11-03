using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JusTeeth.App.ViewModels;
using JusTeeth.Data;
using JusTeeth.Models;
using Microsoft.AspNet.Identity;

namespace JusTeeth.App.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController() : base(new UnitOfWorkData())
        {
        }

        public ActionResult GetUserPicture(string id)
        {
            var user = this.Db.UsersRepository.All()
                .Include(x=>x.Department)
                .Include(x=>x.Department.Workplace)
                .FirstOrDefault(x => x.UserName == id);

            LightUserViewModel model = new LightUserViewModel()
            {
                Avatar = user.Avatar,
                Company = user.Department.Workplace.Name,
                Department = user.Department.Name,
                FacebookProfile = user.FacebookProfile,
                DisplayName = user.DisplayName
            };

            return PartialView("_UserPicture", model);
        }

        [HttpGet]
        public ActionResult Index(string username)
        {
            var user = this.Db.UsersRepository.GetUserByUsername(username);
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                Avatar = user.Avatar,
                FacebookProfile = user.FacebookProfile,
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Department = user.Department.Name,
                Workplace = user.Department.Workplace.Name,
                GroupHistory = user.GroupHistory != null ? user.GroupHistory.Select(x => new HungryGroupViewModel()
                {
                    Id =  x.Id,
                    Creator = x.Creator.UserName,
                    Place = x.Place.Name,
                }).ToList() : null,
                Friends =  user.Friends != null ? user.Friends.Select(x => new UserFriendModel()
                {
                    Avatar = x.Avatar,
                    Department = x.Department.Name,
                    FacebookProfile = x.FacebookProfile,
                    DisplayName = x.DisplayName,
                    UserName = x.UserName,
                    Id = x.Id,
                }).ToList() : null,
                LastPlaces = user.LastPlaces != null ? user.LastPlaces.Select(x => new PlaceViewModel()
                {
                    Name = x.Name,
                    Rating = x.Rating,
                    Id = x.Id,
                    AlternativeName = x.AlternativeName,
                    Description = x.Description,
                    Address = x.Address,
                }).ToList() : null
            };

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = this.Db.UsersRepository.All().FirstOrDefault(u => u.Id == userId);

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.Db.UsersRepository.All().FirstOrDefault(u => u.Id == model.Id);
                user.DisplayName = model.DisplayName;
                user.FacebookProfile = model.FacebookProfile;

                if (model.Avatar.ContentLength > 0)
                {
                    var fileName = user.UserName + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/Content/UserPhotos"), fileName);
                    model.Avatar.SaveAs(path);
                    user.Avatar = fileName;
                }

                this.Db.SaveChanges();
            }

            return RedirectToAction("EditProfile");
        }

        public ActionResult Friend(string username)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Db.UsersRepository.GetUserByUserId(userId);

            var friend = this.Db.UsersRepository.GetUserByUsername(username);

            user.Friends.Add(friend);
            this.Db.SaveChanges();

            return null;
        }
    }
}