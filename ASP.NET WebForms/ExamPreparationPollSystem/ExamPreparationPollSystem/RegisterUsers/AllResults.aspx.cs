using ExamPreparationPollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamPreparationPollSystem
{
    public partial class AllResults : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
          //  var context = new ExamPreparationPollSystem.Models.PollSystemEntities();
          //  var questions = context.Questions.OrderBy(x => x.Text).ToList();
          //  this.GridViewAllQuestions.DataSource = questions;
          //  this.GridViewAllQuestions.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterAllResultsAnswers.DataSource = null;
            this.RepeaterAllResultsAnswers.DataBind();
        }

        protected void GridViewAllQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int questionId = Convert.ToInt32(this.GridViewAllQuestions.SelectedDataKey.Value);
            
            var context = new ExamPreparationPollSystem.Models.PollSystemEntities();
            var answers = context.Answers.Where(x => x.QuestionId == questionId).ToList();
            this.RepeaterAllResultsAnswers.DataSource = answers;
            this.RepeaterAllResultsAnswers.DataBind();
        }

      // protected void GridViewAllQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
      // {
      //     this.GridViewAllQuestions.PageIndex = e.NewPageIndex;
      // }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Question> GridViewAllQuestions_GetData()
        {
            var context = new ExamPreparationPollSystem.Models.PollSystemEntities();
            var questions = context.Questions.OrderBy(q => q.Text);
            return questions;
        }
    }
}