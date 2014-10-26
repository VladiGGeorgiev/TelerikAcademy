using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationControls
{
    public partial class Register : System.Web.UI.Page
    {
        public void PersonInfoBtn_Click(object sender, EventArgs e)
        {
            this.CheckIsValid("personalInfo");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (!this.accept.Checked)
            {
                this.acceptValidator.IsValid = false;
            }

            if (this.CheckIsValid("loginInfo"))
            {

            }

            if (this.CheckIsValid("additinalInfo"))
            {

            }

            if (this.CheckIsValid("personalInfo"))
            {
                //do something
            }
        }

        protected void LoginValidate_Click(object sender, EventArgs e)
        {
            this.CheckIsValid("loginInfo");
        }

        protected void AdditinalInfoBtn_Click(object sender, EventArgs e)
        {
            this.CheckIsValid("additinalInfo");
        }

        private bool CheckIsValid(string validationGroup)
        {
            this.Page.Validate(validationGroup);
            if (this.Page.IsValid)
            {
                return true;
            }
            return false;
        }
    }
}