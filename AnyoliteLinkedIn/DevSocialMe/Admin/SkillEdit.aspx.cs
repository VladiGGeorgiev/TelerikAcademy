using DevSocialMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace DevSocialMe.Admin
{
    public partial class SkillEdit : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var id = Request.Params["id"];

            if (id == null)
            {
                Response.Redirect("~/Admin/Skills");
            }

            if (!String.IsNullOrEmpty(id))
            {
                int skillId = int.Parse(id);
                var context = new ApplicationDbContext();

                var selectedSkill = context.Skills.FirstOrDefault(s => s.SkillId == skillId);

                this.TextBoxUpdatedSkillName.Text = selectedSkill.Name;
            }
        }

        protected void EditMySkill_Command(object sender, CommandEventArgs e)
        {
            int skillId = Convert.ToInt32(Request.Params["id"]);

            if (skillId == 0)
            {
                Response.Redirect("~/Admin/Skills");
            }

            var context = new ApplicationDbContext();
            try
            {
                var selectedSkill = context.Skills.FirstOrDefault(s => s.SkillId == skillId);
                selectedSkill.Name = this.TextBoxUpdatedSkillName.Text;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            Response.Redirect("~/Admin/Skills");
        }
    }
}