using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.App.Controllers
{
    public class TweetsController : Controller
    {
        private IUnitOfWork db;

        public TweetsController(IUnitOfWork db)
        {
            this.db = db;
        }

        public TweetsController()
            : this(new UnitOfWork())
        {
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Home");
            }

            var currentUser = User.Identity.Name;
            var currentUserTweets = db.Tweets.All().Where(t => t.Creator.UserName == currentUser).ToList();

            return View(currentUserTweets);
        }

        public ActionResult Create(Tweet model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = User.Identity.Name;
                var creator = db.Users.All().FirstOrDefault(u => u.UserName == currentUser);

                List<HashTag> tags = new List<HashTag>();
                List<string> modelTags = model.Content.Split(' ').Where(x => x.Contains('#')).ToList();
                foreach (var tag in modelTags)
                {
                    HashTag checkedTag = db.HashTags.All().FirstOrDefault(t => t.Name == tag);

                    if (checkedTag == null)
                    {
                        checkedTag = new HashTag()
                        {
                            Name = tag
                        };
                        db.HashTags.Add(checkedTag);
                        db.SaveChanges();
                    }

                    tags.Add(checkedTag);
                }

                var newTweet = new Tweet()
                {
                    Creator = creator,
                    Content = model.Content,
                    TweetTags = tags
                };

                db.Tweets.Add(newTweet);
                db.SaveChanges();

                foreach (var tag in tags)
                {
                    tag.TagTweets.Add(newTweet);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}