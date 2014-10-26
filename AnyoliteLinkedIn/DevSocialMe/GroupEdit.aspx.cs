using DevSocialMe.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevSocialMe
{
    public partial class GroupEdit : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {  
            var id = Request.Params["id"];

            if (!String.IsNullOrEmpty(id))
            {
                int groupId = int.Parse(id);
                ApplicationDbContext context = new ApplicationDbContext();

                Group selectedGroup = null;
                try
                {
                    selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }

                if (selectedGroup.Creator == User.Identity.Name || User.IsInRole("Admin"))
                {
                    this.TextBoxUpdatedGroupTitle.Text = selectedGroup.Title;
                }
                else
                {
                    ErrorSuccessNotifier.AddInfoMessage("You have no success!");
                    Response.Redirect("~/Groups");
                }
            }
        }

        protected void EditMyGroup_Command(object sender, CommandEventArgs e)
        {
            int groupId = int.Parse(Request.Params["id"]);

            var context = new ApplicationDbContext();
            var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
            
            if (selectedGroup.Creator == User.Identity.Name || User.IsInRole("Admin"))
            {
                try
                {
                    selectedGroup.Title = this.TextBoxUpdatedGroupTitle.Text;
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Group title edited!");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }

            Response.Redirect("~/Groups");
        }
    }
}