using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssemblyLocation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Hello.Text = "Hello, ASP.NET WebForms";
            this.Container.Text = "Assembly path: " + Assembly.GetExecutingAssembly().Location;
        }
    }
}