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
    public partial class GroupView : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var id = Request.Params["id"];
            if (!String.IsNullOrEmpty(id))
            {
                int groupId = int.Parse(id);
                var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);

                try
                {
                    if (selectedGroup.Creator == User.Identity.Name || User.IsInRole("Admin"))
                    {
                        var messages = selectedGroup.Messages.OrderByDescending(m => m.MessageId).ToList();
                        this.ListViewGroupMessages.DataSource = messages;
                        this.ListViewGroupMessages.DataBind();
                    }
                    else
                    {
                        Response.Redirect("~/Groups");
                    }
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void AddMessage_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            int groupId = int.Parse(Request.Params["id"]);
            var selectedGroup = context.Groups.FirstOrDefault(g => g.GroupId == groupId);

            try
            {
                if (selectedGroup.Creator == User.Identity.Name || User.IsInRole("Admin"))
                {
                    var newMessage = new Message()
                    {
                        Content = this.NewMessage.Text,
                        DateCreated = DateTime.Now,
                        User = context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name)
                    };

                    selectedGroup.Messages.Add(newMessage);
                    context.SaveChanges();

                    this.DataBind();

                    this.NewMessage.Text = "";
                }
                else
                {
                    Response.Redirect("~/Groups");
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void ButtonViewUser_Command(object sender, CommandEventArgs e)
        {
            var userName = e.CommandArgument.ToString();
            var url = "Profile.aspx?username=" + userName;
            Response.Redirect(url);
        }
    }
}