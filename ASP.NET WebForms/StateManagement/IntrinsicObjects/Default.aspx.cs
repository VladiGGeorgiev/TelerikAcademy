using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntrinsicObjects
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralResult.Text = "Browser type: " + Request.Browser.Type;
            this.LiteralResult.Text += "<br />Client IP: " + Request.UserHostAddress;
        }
    }
}