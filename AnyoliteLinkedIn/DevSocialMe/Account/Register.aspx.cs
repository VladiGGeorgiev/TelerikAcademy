using DevSocialMe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DevSocialMe.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string fullName = this.FullName.Text;
            string email = this.Email.Text;
            string summary = this.Summary.Text;
            string localPath = string.Empty;
            string relativePath = string.Empty;

            if (FileUploadControl.HasFile)
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                localPath = Server.MapPath("~/Uploaded_Files/") + filename;
                relativePath = "/Uploaded_Files/" + filename;
                FileUploadControl.SaveAs(localPath);
                StatusLabel.Text = "Upload status: File uploaded!";
            }

            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            var context = new ApplicationDbContext();
            ApplicationUser u = new ApplicationUser() { UserName = userName, FullName = fullName, Email = email, Summary = summary, AvatarUrl = relativePath, };

            var adminId = context.Roles.FirstOrDefault(r => r.Name == "User").Id.ToString();

            manager.Roles.AddUserToRoleAsync(u.Id, adminId);

            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success)
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}