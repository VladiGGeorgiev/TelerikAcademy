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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<ApplicationUser> GridViewAdminUsers_GetData()
        {
            var context = new ApplicationDbContext();

            IQueryable<ApplicationUser> users = null;
            try
            {
                users = 
                (from u in context.Users 
                 select u).OrderBy(u => u.Id);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return users;
        }
    }
}