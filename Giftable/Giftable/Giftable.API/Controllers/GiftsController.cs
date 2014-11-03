using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Giftable.API.AuthenticationHeaders;
using Giftable.API.Models;
using Giftable.Data;
using Giftable.Models;

namespace Giftable.API.Controllers
{
    public class GiftsController : BaseApiController
    {
        [HttpPost]
        [ActionName("new-gift")]
        public HttpResponseMessage AddGift(NewGiftModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var currentUser = this.GetUserByAccessToken(accessToken, context);

                var giftEntity = new Gift
                {
                    Name = model.Name,
                    Description = model.Description,
                    Bought = false,
                    Checked = false,
                    Seen = true
                };

                if (model.Image != null)
                {
                    giftEntity.Image = model.Image;
                }

                if (model.Latitude != null && model.Longitude != null)
                {
                    giftEntity.Latitude = model.Latitude.Value;
                    giftEntity.Longitude = model.Longitude.Value;
                }

                if (model.Url != null)
                {
                    giftEntity.Url = model.Url;
                }

                currentUser.Wishlist.Add(giftEntity);
                context.SaveChanges();

                var responseModel = new GiftCreatedModel()
                {
                    Id = giftEntity.Id,
                    Name = giftEntity.Name
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { listId = listEntity.Id }));
                return response;
            });
        }

        [HttpPost]
        [ActionName("suggest-gift")]
        public HttpResponseMessage AddGift(NewSuggestedGift model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var currentUser = this.GetUserByAccessToken(accessToken, context);
                var giftFor = context.Users.FirstOrDefault(x => x.Username == model.SuggestedFor);
                if (giftFor == null)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var giftEntity = new Gift
                {
                    Name = model.Name,
                    Description = model.Description,
                    SuggestedBy = currentUser,
                    SuggestedFor = giftFor,
                    Bought = false,
                    Checked = false,
                    Seen = false
                };

                if (model.Image != null)
                {
                    giftEntity.Image = model.Image;
                }

                if (model.Latitude != null && model.Longitude != null)
                {
                    giftEntity.Latitude = model.Latitude.Value;
                    giftEntity.Longitude = model.Longitude.Value;
                }

                if (model.Url != null)
                {
                    giftEntity.Url = model.Url;
                }

                giftFor.SuggestedGifts.Add(giftEntity);
                context.SaveChanges();

                var responseModel = new GiftCreatedModel()
                {
                    Id = giftEntity.Id,
                    Name = giftEntity.Name
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { listId = listEntity.Id }));
                return response;
            });
        }

        [HttpGet]
        [ActionName("wishlist")]
        public IQueryable<GiftModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var wishlist = user.Wishlist.AsQueryable().OrderBy(x => x.Name)
                                   .Select(x => new GiftModel
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       Latitude = x.Latitude,
                                       Longitude = x.Longitude,
                                       Image = x.Image,
                                       Url = x.Url,
                                       //SuggestedBy = x.SuggestedBy.Username,
                                       //SuggestedFor = x.SuggestedFor.Username,
                                       Bought = x.Bought,
                                       Checked = x.Checked
                                   });

                return wishlist;
            });
        }

        [HttpGet]
        [ActionName("user-wishlist")]
        public IQueryable<GiftModel> GetUsersWishlist(string email,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var targetedUser = context.Users.FirstOrDefault(x => x.Email == email);
                IQueryable<GiftModel> wishlist = null;
                if (targetedUser == null)
                {
                    //TODO: error handling
                }
                else
                {
                    wishlist = targetedUser.Wishlist.AsQueryable().OrderBy(x => x.Name)
                                   .Select(x => new GiftModel
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       Latitude = x.Latitude,
                                       Longitude = x.Longitude,
                                       Image = x.Image,
                                       Url = x.Url,
                                       //SuggestedBy = x.SuggestedBy.Username,
                                       //SuggestedFor = x.SuggestedFor.Username,
                                       Bought = x.Bought,
                                       Checked = x.Checked
                                   });
                }

                return wishlist;
            });
        }

        [HttpGet]
        [ActionName("suggested-list")]
        public IQueryable<GiftModel> GetSuggested(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var wishlist = user.SuggestedGifts.AsQueryable().OrderBy(x => x.Name)
                        .Select(x => new GiftModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Latitude = x.Latitude,
                            Longitude = x.Longitude,
                            Image = x.Image,
                            Url = x.Url,
                            //SuggestedBy = x.SuggestedBy.Username,
                            //SuggestedFor = x.SuggestedFor.Username,
                            Bought = x.Bought,
                            Checked = x.Checked,
                            Seen = x.Seen
                        });

                return wishlist;
            });
        }

        [HttpGet]
        [ActionName("get-unseen")]
        public IQueryable<GiftModel> GetUnseenSuggestedGifts(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var unseen = user.SuggestedGifts.AsQueryable().OrderBy(x => x.Name)
                        .Where(x => x.Seen == false)
                        .Select(x => new GiftModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Latitude = x.Latitude,
                            Longitude = x.Longitude,
                            Image = x.Image,
                            Url = x.Url,
                            SuggestedBy = x.SuggestedBy.Username,
                            SuggestedFor = x.SuggestedFor.Username,
                            Bought = x.Bought,
                            Checked = x.Checked,
                            Seen = x.Seen
                        });

                //mark gifts as seen
                foreach (var giftModel in unseen)
                {
                    giftModel.Seen = true;
                }

                return unseen;
            });
        }

        [HttpGet]
        [ActionName("located-gifts")]
        public IQueryable<GiftModel> GetGiftsWithLocation(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var gifts = context.Gifts.AsQueryable().OrderBy(x => x.Name)
                        .Where(x => x.Latitude != null && x.Longitude != null)
                        .Select(x => new GiftModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Latitude = x.Latitude,
                            Longitude = x.Longitude,
                            Image = x.Image,
                            Url = x.Url,
                            SuggestedBy = x.SuggestedBy.Username,
                            SuggestedFor = x.SuggestedFor.Username,
                            Bought = x.Bought,
                            Checked = x.Checked,
                            Seen = x.Seen
                        });

                return gifts;
            });
        }

        [HttpGet]
        [ActionName("details")]
        public HttpResponseMessage GiftDetails(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();

                var responseModel = context.Gifts.Where(x => x.Id == id)
                                    .Select(x => new GiftModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Latitude = x.Latitude,
                                        Longitude = x.Longitude,
                                        Image = x.Image,
                                        Url = x.Url,
                                        Bought = x.Bought,
                                        Checked = x.Checked,
                                        Seen = x.Seen,
                                        SuggestedBy = x.SuggestedBy.Username,
                                        SuggestedFor = x.SuggestedFor.Username
                                    }).FirstOrDefault();

                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);

                return response;
            });
        }
    }
}
