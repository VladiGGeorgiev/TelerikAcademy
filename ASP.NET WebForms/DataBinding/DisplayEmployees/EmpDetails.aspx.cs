using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DisplayEmployees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["EmployeeID"] == null)
            {
                Response.Redirect("Employees.aspx");
            }

            var id = int.Parse(Request.Params["EmployeeID"]);

            var context = new NORTHWNDEntities();
            var employee = context.Employees.Where(x => x.EmployeeID == id).ToList();
            this.DetailsViewEmployeeDetails.DataSource = employee;
            this.DetailsViewEmployeeDetails.DataBind();
        }
    }
}