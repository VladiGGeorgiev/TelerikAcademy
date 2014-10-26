using DevSocialMe.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevSocialMe.Admin
{
    public partial class GroupEdit : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var id = Request.Params["id"];

            if (id == null)
            {
                Response.Redirect("~/Admin/Groups");
            }

            if (!String.IsNullOrEmpty(id))
            {
                int groupId = int.Parse(id);
                var context = new ApplicationDbContext();

                try
                {
                    var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                    this.TextBoxUpdatedGroupTitle.Text = selectedGroup.Title;
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void EditMyGroup_Command(object sender, CommandEventArgs e)
        {
            int groupId = Convert.ToInt32(Request.Params["id"]);

            if (groupId == 0)
            {
                Response.Redirect("~/Admin/Groups");
            }

            var context = new ApplicationDbContext();

            try
            {
                var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                selectedGroup.Title = this.TextBoxUpdatedGroupTitle.Text;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            Response.Redirect("~/Admin/Groups");
        }
    }
}