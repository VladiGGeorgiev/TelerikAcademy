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
    public partial class Profile : System.Web.UI.Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["username"] == null)
            {
                Response.Redirect("Profile?username=" + User.Identity.Name);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var currentUserName = Request.Params["username"];
            var context = new ApplicationDbContext();

            try
            {
                var loggedUser = context.Users.Include(u => u.Skills).FirstOrDefault(u => u.UserName == currentUserName);
                var curentLoggedUserName = Context.User.Identity.Name;

                if (curentLoggedUserName != currentUserName)
                {
                    this.ShowHideSkillsForm.Visible = false;
                }

                if (loggedUser != null)
                {
                    this.ImageUser.ImageUrl = Server.HtmlEncode(loggedUser.AvatarUrl);
                    this.LiteralFullName.Text = Server.HtmlEncode(loggedUser.FullName);
                    this.LiteralEmail.Text = Server.HtmlEncode(loggedUser.Email);
                    this.LiteralSummary.Text = Server.HtmlEncode(loggedUser.Summary);

                    if (loggedUser.Skills.Any())
                    {
                        this.LiteralSkills.Text = "Skills";
                        this.RepeaterSkills.DataSource = loggedUser.Skills.ToList().OrderByDescending(s => s.Votes.Count());
                    }
                    this.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        public IQueryable<DevSocialMe.Models.Group> GridViewGroups_GetData()
        {
            var currentUserName = Request.Params["username"];
            var context = new ApplicationDbContext();
            var loggedUser = context.Users.Include(u => u.Groups).FirstOrDefault(u => u.UserName == currentUserName);

            if (loggedUser != null)
            {
                if (loggedUser.Groups.Count > 0)
                {
                    this.LiteralGroups.Text = "Groups";
                    return loggedUser.Groups.AsQueryable();
                }
            }
            return null;
        }

        protected void ImageButtonViewProfile_Command(object sender, CommandEventArgs e)
        {
            var userName = e.CommandArgument.ToString();
            var url = "Profile.aspx?username=" + userName;
            Response.Redirect(url);
        }

        protected void ButtonEndorce_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var targetUserName = Request.Params["username"];
            var currentUserName = Context.User.Identity.Name;

            try
            {
                var targetUser = context.Users.Include(u => u.Skills).FirstOrDefault(u => u.UserName == targetUserName);
                var currentUser = context.Users.Include(u => u.Skills).FirstOrDefault(u => u.UserName == currentUserName);
                if (targetUser.UserName != currentUser.UserName)
                {
                    var skillName = e.CommandArgument.ToString();
                    var targetSkill = targetUser.Skills.FirstOrDefault(s => s.Name == skillName);

                    if (!targetUser.Skills.FirstOrDefault(s => s.Name == skillName).Votes.Any(s => s.User.UserName == currentUser.UserName))
                    {
                        targetUser.Skills.FirstOrDefault(s => s.Name == skillName).Votes.Add(new Vote() { SkillId = targetSkill, User = currentUser });
                        context.SaveChanges();
                        this.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void ShowHideSkillsForm_Command(object sender, CommandEventArgs e)
        {
            if (this.PanelAddSkill.Visible)
            {
                this.PanelAddSkill.Visible = false;
            }
            else
            {
                this.PanelAddSkill.Visible = true;
            }
        }

        protected void ButtonAddSkill_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var userName = Context.User.Identity.Name;
            var skillName = TextBoxSkillName.Text.ToString();

            try
            {
                var user = context.Users.Include(x => x.Skills).FirstOrDefault(x => x.UserName == userName);
                var skill = context.Skills.FirstOrDefault(s => s.Name == skillName);

                if (skill != null)
                {
                    context.Users.Include(x => x.Skills).FirstOrDefault(x => x.UserName == userName).Skills.Add(skill);
                }
                else
                {
                    var newSkill = new Skill() { Name = skillName };
                    context.Skills.Add(newSkill);
                    context.Users.Include(x => x.Skills).FirstOrDefault(x => x.UserName == userName).Skills.Add(newSkill);
                }
                context.SaveChanges();
                this.TextBoxSkillName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }

}