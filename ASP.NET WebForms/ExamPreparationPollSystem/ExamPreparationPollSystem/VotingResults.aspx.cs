using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamPreparationPollSystem.Models;

namespace ExamPreparationPollSystem
{
    public partial class VotingResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int questionId = Convert.ToInt32(Request.Params["questionId"]);
            var context = new PollSystemEntities();
            var question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);

            this.LiteralQuestion.Text = question.Text;
            this.RepeaterAnswerResult.DataSource = question.Answers.ToList();
            this.DataBind();
        }
    }
}