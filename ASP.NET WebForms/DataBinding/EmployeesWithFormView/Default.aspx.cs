using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesWithFormView
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewEmployee_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.FormViewEmployee.PageIndex = this.GridViewEmployees.SelectedIndex;
            this.FormViewEmployee.DataBind();
        }
    }
}