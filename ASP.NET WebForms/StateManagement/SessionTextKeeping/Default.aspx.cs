using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionTextKeeping
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((List<string>)Session["list"]) == null)
            {
                var list = new List<string>();
                Session["list"] = list;
            }

            if (!IsPostBack)
            {
                foreach (var item in ((List<string>)Session["list"]))
                {
                    this.LabelOutputText.Text += item + "<br />";
                }
            }
        }

        protected void ButtonSaveText_Click(object sender, EventArgs e)
        {
            var text = this.TextBoxInput.Text;
            ((List<string>)Session["list"]).Add(text);
            this.LabelOutputText.Text += text + "<br />";
        }
    }
}