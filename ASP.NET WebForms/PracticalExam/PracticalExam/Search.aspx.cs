using Error_Handler_Control;
using PracticalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticalExam
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var searchText = Request.Params["q"];
            this.LiteralSearchTitle.Text = searchText;
            var searchTextToLower = searchText.ToLower();
            var context = new ApplicationDbContext();

            try
            {
                var books = context.Books
                    .Where(x => x.Title.ToLower().Contains(searchTextToLower) || x.Author.ToLower().Contains(searchTextToLower))
                    .OrderBy(b => b.Title).ThenBy(t => t.Author);
                this.RepeaterSearchResults.DataSource = books.ToList();
                this.RepeaterSearchResults.DataBind();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}