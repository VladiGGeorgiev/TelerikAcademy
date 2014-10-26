using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamPreparationPollSystem.Models;

namespace ExamPreparationPollSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new PollSystemEntities();
            var questions = context.Questions.Take(3);
            this.ListViewQuestions.DataSource = questions.ToList();

            this.DataBind();
        }

        protected void LinkButtonVote_Command(object sender, CommandEventArgs e)
        {
            int answerId = Convert.ToInt32(e.CommandArgument);
            var context = new PollSystemEntities();
            Answer answer = context.Answers.Find(answerId);
            answer.Votes++;
            context.SaveChanges();

            Response.Redirect("VotingResults.aspx?questionId=" + answer.QuestionId);
        }
    }
}