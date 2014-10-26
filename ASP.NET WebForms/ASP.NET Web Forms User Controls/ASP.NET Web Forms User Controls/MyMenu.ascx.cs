using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Web_Forms_User_Controls
{
    [ParseChildren(true)]
    public partial class MyMenu : System.Web.UI.UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<MenuItem> Items { get; set; }
      
        protected override void AddParsedSubObject(object obj)
        {
            if (obj.GetType() == typeof(MenuItem))
                this.Items.Add((MenuItem)obj);
            else
                base.AddParsedSubObject(obj);
        }
        
        protected void Page_Prerender(object sender, EventArgs e)
        {
            this.menuList.DataSource = Items;
            this.menuList.DataBind();
        }
    }

    public class MenuItem : WebControl, INamingContainer
    {

        public string Title { get; set; }
        public string Href { get; set; }

    }
}