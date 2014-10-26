using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PracticalExam.Models;
using Error_Handler_Control;

namespace PracticalExam
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new ApplicationDbContext();
            ICollection<Category> categories = null;
            try
            {
                categories = context.Categories.OrderBy(c => c.Title).ToList();
                if (categories == null || categories.Count == 0)
                {
                    (this.ListViewCategories.FindControl("NoResults") as Literal).Text = "No books in this category.";
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.ListViewCategories.DataSource = categories;
            this.ListViewCategories.DataBind();
        }

        protected void LinkButtonSearch_Command(object sender, CommandEventArgs e)
        {
            var searchText = this.TextBoxSearch.Text;

            if (searchText.Length > 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("Too long query. Max length of query could be less than 100");
                Response.Redirect("/Default");
            }


            Response.Redirect("Search?q=" + searchText);
        }
    }
}