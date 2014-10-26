using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETIntroduction
{
    public partial class SumNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SumButton_Click(object sender, EventArgs e)
        {
            decimal firstNumber;
            bool isValidFirstNumber = decimal.TryParse(this.FirstNumber.Text, out firstNumber);
            
            decimal secondNumber;
            bool isValidSeconNumber = decimal.TryParse(this.SecondNumber.Text, out secondNumber);
            if (isValidFirstNumber && isValidSeconNumber)
            {
                this.resultSum.Text = (firstNumber + secondNumber).ToString();
            }
            else
            {
                this.resultSum.Text = "Please input valid numbers!";
            }
        }
    }
}