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
    public partial class Skills : Page
    {
        public IQueryable<Skill> GridViewAllSkills_GetData()
        {
            var context = new ApplicationDbContext();

            IOrderedQueryable<Skill> allSkills = null;
            try
            {
                allSkills = 
                (from s in context.Skills 
                select s).OrderBy(s => s.SkillId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return allSkills;
        }

        protected void ButtonDeleteSkill_Command(object sender, CommandEventArgs e)
        {
            int skillId = Convert.ToInt32(e.CommandArgument);
            var context = new ApplicationDbContext();

            try
            {
                var selectedSkill = context.Skills.FirstOrDefault(s => s.SkillId == skillId);
                context.Skills.Remove(selectedSkill);
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