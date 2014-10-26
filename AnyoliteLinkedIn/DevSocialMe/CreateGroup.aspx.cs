using DevSocialMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Error_Handler_Control;

namespace DevSocialMe
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCreateGroup_Command(object sender, CommandEventArgs e)
        {

            var newGroup = new Group()
            {
                Title = this.NewGroupTitle.Text,
                Creator = User.Identity.Name,
                CreationData = DateTime.Now
            };

            ApplicationDbContext context = new ApplicationDbContext();

            try
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == newGroup.Creator);
                user.Groups.Add(newGroup);
                context.Groups.Add(newGroup);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Group created!");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            Response.Redirect("~/Groups");
        }
    }
}