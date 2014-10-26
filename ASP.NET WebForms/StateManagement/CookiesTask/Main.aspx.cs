using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiesTask
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie == null)
            {
                this.Response.Redirect("Login.aspx");
            }
            else
            {
                this.LabelOutputGreeting.Text = "Hello, " + cookie.Value;
            }
        }
    }
}