namespace Forum.WebApi.Controllers
{
    using Forum.Models;
    using Forum.WebApi.Models;
    using Forum.WebApi.Attributes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;

    public class TagsController : BaseApiController
    {
        private readonly IDbContextFactory<DbContext> contextFactory;

        public TagsController()
        {
            this.contextFactory = new DbForumContextFactory();
        }

        public TagsController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpGet]
        public IQueryable<TagReturnModel> AllTags([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            IOrderedQueryable<TagReturnModel> responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = this.contextFactory.Create();


                var user = context.Set<User>().Where(x => x.SessionKey == sessionKey).FirstOrDefault();

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid session key authentication!");
                }

                var allTags = context.Set<Tag>().Select(TagReturnModel.FromTag).OrderBy(x => x.Name);

                return allTags;

            });

            return responseMessage;
        }
    }
}
