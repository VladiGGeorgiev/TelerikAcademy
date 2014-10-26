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
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bookId = Convert.ToInt32(Request.Params["id"]);
            var context = new ApplicationDbContext();
            ICollection<Book> book = null;
            try
            {
                book = context.Books.Where(x => x.BookId == bookId).ToList();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.FormViewBook.DataSource = book;
            this.FormViewBook.DataBind();
        }
    }
}