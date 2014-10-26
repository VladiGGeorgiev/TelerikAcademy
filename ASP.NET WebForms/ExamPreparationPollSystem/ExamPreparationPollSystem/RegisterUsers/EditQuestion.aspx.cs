using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamPreparationPollSystem.Models;
using Error_Handler_Control;

namespace ExamPreparationPollSystem.RegisterUsers
{
    public partial class EditQuestion : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string questionIdStr = Request.Params["questionId"];
            if (!string.IsNullOrEmpty(questionIdStr))
            {
                int questionId = Convert.ToInt32(questionIdStr);
                using (var context = new PollSystemEntities())
                {
                    Question question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
                    this.TextBoxQuestionText.Text = question.Text;
                    this.RepeaterAnswerResult.DataSource = question.Answers.ToList();
                    this.RepeaterAnswerResult.DataBind();
                }
            }
        }

        protected void LinkButtonSaveQuestion_Click(object sender, EventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                string questionIdStr = Request.Params["questionId"];
                Question question;
                if (string.IsNullOrEmpty(questionIdStr))
                {
                    question = new Question();
                    context.Questions.Add(question);
                }
                else
                {
                    int questionId = Convert.ToInt32(questionIdStr);
                    question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
                }

                question.Text = this.TextBoxQuestionText.Text;

                try
                {
                    context.SaveChanges();
                    Response.Redirect("EditQuestions.aspx", false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}