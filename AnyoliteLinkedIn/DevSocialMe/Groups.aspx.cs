using System.Collections;
using DevSocialMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace DevSocialMe
{
    public partial class Groups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Group> GridViewMyGroups_GetData()
        {
            var context = new ApplicationDbContext();

            IQueryable<Group> myGroups = null;
            try
            {
                myGroups =
                (from gr in context.Groups
                 where gr.Creator == User.Identity.Name
                 select gr).OrderBy(g => g.GroupId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return myGroups;
        }

        public IQueryable<Group> GridViewAllGroups_GetData()
        {
            var context = new ApplicationDbContext();

            IQueryable<Group> allGroups = null;
            try
            {
                allGroups =
                (from gr in context.Groups
                where gr.Creator != User.Identity.Name && gr.Users.All(u => u.UserName != User.Identity.Name)
                select gr).OrderBy(g => g.GroupId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return allGroups;
        }

        protected void ButtonJoinGroup_Command(object sender, CommandEventArgs e)
        {
            int groupId = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();

            try
            {
                var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                var currentUser = new ApplicationUser();
                currentUser = context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                selectedGroup.Users.Add(currentUser);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.DataBind();
        }

        public IQueryable<Group> GridViewJoinedGroups_GetData()
        {
            var context = new ApplicationDbContext();

            IQueryable<Group> groups = null;
            try
            {
                var currentUser = new ApplicationUser();
                currentUser = context.Users.Include("Groups")
                    .FirstOrDefault(u => u.UserName == User.Identity.Name);
                groups = currentUser.Groups.OrderBy(g => g.GroupId).AsQueryable();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return groups;
        }
    }
}