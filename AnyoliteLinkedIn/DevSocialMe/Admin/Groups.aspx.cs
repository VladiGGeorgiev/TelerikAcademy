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
    public partial class Groups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<DevSocialMe.Models.Group> GridViewAllGroups_GetData()
        {
            var context = new ApplicationDbContext();

            IQueryable<Group> allGroups = null;
            try
            {
                allGroups =
                    (from gr in context.Groups
                     select gr).OrderBy(g => g.GroupId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return allGroups;
        }

        protected void ButtonDeleteGroup_Command(object sender, CommandEventArgs e)
        {
            int groupId = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();

            try
            {
                var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                context.Groups.Remove(selectedGroup);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}