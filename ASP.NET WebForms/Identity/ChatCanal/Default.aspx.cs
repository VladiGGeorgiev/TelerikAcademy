using ChatCanal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatCanal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewPosts.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ChatCanal.Models.Post> ListViewPosts_GetData()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Posts;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewPosts_DeleteItem(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var post = context.Posts.Find(id);
            context.Posts.Remove(post);
            context.SaveChanges();

            ListViewPostsRebind();
        }

        private void ListViewPostsRebind()
        {
            this.ListViewPosts.SelectMethod = "ListViewPosts_GetData";
            this.ListViewPosts.DataBind();
        }

        public void ListViewPosts_InsertItem()
        {
            var post = new ChatCanal.Models.Post();
            TryUpdateModel(post);
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewPosts_UpdateItem(int id)
        {
            ChatCanal.Models.Post post = null;
            ApplicationDbContext context = new ApplicationDbContext();
            post = context.Posts.Find(id);

            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (post == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(post);
            if (ModelState.IsValid)
            {
                context.SaveChanges();
            }
        }
    }
}