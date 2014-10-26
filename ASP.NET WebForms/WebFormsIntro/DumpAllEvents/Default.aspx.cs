using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DumpAllEvents
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page Pre init! <br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page init! <br/>");
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page loaded! <br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page pre render! <br/>");
        }
    }
}