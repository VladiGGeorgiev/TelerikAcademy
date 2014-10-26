using Counter.Data;
using Counter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;

namespace DbCounter
{
    public partial class Default : System.Web.UI.Page
    {
        private CounterContext context;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.context = new CounterContext();

            context.Logs.Add(new Log()
            {
                IpAddres = this.GetIpAddress(),
                VisitingDate = DateTime.Now
            });

            context.SaveChanges();
        }

        private string GetIpAddress()
        {
            string address = string.Empty;

            foreach (IPAddress ipa in Dns.GetHostAddresses(Request.ServerVariables["REMOTE_ADDR"].ToString()))
            {
                if (ipa.AddressFamily.ToString() == "InterNetwork")
                {
                    address = ipa.ToString();
                    break;
                }
            }

            if (address != string.Empty)
            {
                return address;
            }

            foreach (IPAddress ipa in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ipa.AddressFamily.ToString() == "InterNetwork")
                {
                    address = ipa.ToString();
                    break;
                }
            }

            return address;
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
                    graphics.DrawString(string.Format("Visits -> {0} times.", context.Logs.Count()),
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