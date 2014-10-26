using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentsRegistration
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var firstName = Server.HtmlEncode(this.firstName.Text);
            var lastName = Server.HtmlEncode(this.lastName.Text);
            var facNumber = Server.HtmlEncode(this.facultyNumber.Text);
            var university = Server.HtmlEncode(this.dropDownListUniversity.SelectedItem.Text);
            var speciality = Server.HtmlEncode(this.dropDownListSpeciality.SelectedItem.Text);
            var courses = this.listBoxCourses.Items;

            HtmlGenericControl wrapper = new HtmlGenericControl("div");
            HtmlGenericControl heading = new HtmlGenericControl("h2");
            heading.InnerText = "Student Information:";
            wrapper.Controls.Add(heading);

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Student name: " + firstName + " " + lastName
            });

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Faculty number: " + facNumber
            });

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "University: " + university
            });

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Speciality: " + speciality
            });

            var listCourses = new List<string>();
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Selected)
                {
                    listCourses.Add(courses[i].ToString());
                }
            }

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Courses: " + string.Join(", ", listCourses)
            });

            Page.Controls.Add(wrapper);
        }
    }
}