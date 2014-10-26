using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoViewer
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            string mySlideDir = AppDomain.CurrentDomain.BaseDirectory + "Slides";
            DirectoryInfo di = new DirectoryInfo(mySlideDir);

            var mySlides = from f in di.GetFiles("*.jpg", SearchOption.TopDirectoryOnly)
                           orderby f.Name
                           select new AjaxControlToolkit.Slide
                           {
                               Name = f.Name,
                               ImagePath = "Slides/" + f.Name,
                               Description = f.Name.TrimEnd(".jpeg".ToCharArray())
                           };
            return mySlides.ToArray();
        }
    }
}