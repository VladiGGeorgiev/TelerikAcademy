using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersGenerator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateNumber_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int start = int.Parse(this.startNumber.Text);
            int end = int.Parse(this.endNumber.Text);
            int number = rand.Next(start, end);
            this.generatedNumber.Text = number.ToString();
        }
    }
}