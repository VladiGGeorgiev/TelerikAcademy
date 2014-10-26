using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees_Orders
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NorthwindEntities context = new NorthwindEntities();
                var employees =
                    (from employee in context.Employees
                     select employee).ToList();
                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }

            
        }

        protected void GridViewEmployees_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }

        protected void GetOrders()
        {
                
        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {

            System.Threading.Thread.Sleep(3000);

            NorthwindEntities context = new NorthwindEntities();
            int employeeId = int.Parse(e.CommandArgument.ToString());
            var orders =
                (from order in context.Orders
                 where order.EmployeeID == employeeId
                 select order).ToList();
            this.GridViewOrders.DataSource = orders;
            this.GridViewOrders.DataBind();
        }
    }
}