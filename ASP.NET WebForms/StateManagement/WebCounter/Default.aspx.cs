using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCounter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Application.Lock();
            if (Application["Visits"] == null)
            {
                Application["Visits"] = 0;
            }
            else
            {
                Application["Visits"] = (int)Application["Visits"] + 1;
            }

            Application.UnLock();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();

            Bitmap image = new Bitmap(200, 200);
            using (image)
            {
                Graphics graphics = Graphics.FromImage(image);
                using (graphics)
                {
                    graphics.DrawString(string.Format("Visits -> {0} times.", Application["Visits"].ToString()),
                        new Font("Segoe UI", 15),
                        new SolidBrush(Color.Magenta),
                        new PointF(10, 65));

                    Response.ContentType = "image/gif";

                    image.Save(Response.OutputStream, ImageFormat.Gif);
                }
            }
        }
    }
}