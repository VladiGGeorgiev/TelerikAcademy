using Error_Handler_Control;
using ExamPreparationPollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamPreparationPollSystem
{
    public partial class EditQuestions : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Question> GridViewAllQuestions_GetData()
        {
            var context = new PollSystemEntities();
            var questions = context.Questions.OrderBy(q => q.Text);
            return questions;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewQuestions_DeleteItem(int questionId)
        {
            var context = new PollSystemEntities();
            Question question = context.Questions.Include("Answers")
                .FirstOrDefault(q => q.QuestionId == questionId);
            try
            {
                context.Answers.RemoveRange(question.Answers);
                context.Questions.Remove(question);
                context.SaveChanges();
                this.GridViewQuestions.PageIndex = 0;
                ErrorSuccessNotifier.AddInfoMessage("Question deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}