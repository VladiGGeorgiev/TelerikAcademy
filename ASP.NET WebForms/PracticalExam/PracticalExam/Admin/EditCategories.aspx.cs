using Error_Handler_Control;
using PracticalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticalExam.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var context = new ApplicationDbContext();
                var categories = context.Categories.ToList();
                this.GridViewCategories.DataSource = categories;
                this.GridViewCategories.DataBind();
            }
        }

        protected void ButtonShowEditForm_Command(object sender, CommandEventArgs e)
        {
            this.FormViewDeleteCategory.DataSource = null;
            this.FormViewDeleteCategory.DataBind();
            this.PanelCreateCategory.Visible = false;
            this.LinkButtonShowCreateCategory.Visible = false;

            var context = new ApplicationDbContext();
            var categoryId = Convert.ToInt32(e.CommandArgument);
            var category = context.Categories.Where(x => x.CategoryId == categoryId);
            this.FormViewEditCategory.DataSource = category.ToList();
            this.FormViewEditCategory.DataBind();
        }

        protected void ShowDeleteForm_Command(object sender, CommandEventArgs e)
        {
            this.FormViewEditCategory.DataSource = null;
            this.FormViewEditCategory.DataBind();
            this.PanelCreateCategory.Visible = false;
            this.LinkButtonShowCreateCategory.Visible = false;

            this.LinkButtonShowCreateCategory.Visible = false;
            var context = new ApplicationDbContext();
            var categoryId = Convert.ToInt32(e.CommandArgument);
            var category = context.Categories.Where(x => x.CategoryId == categoryId);
            this.FormViewDeleteCategory.DataSource = category.ToList();
            this.FormViewDeleteCategory.DataBind();
        }
        
        protected void LinkButtonDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var categoryId = Convert.ToInt32(e.CommandArgument);
            var category = context.Categories.Include("Books").FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                try
                {
                    context.Books.RemoveRange(category.Books);
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("Category {0} removed!", category.Title));
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Can not remove category with id: " + categoryId);
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonCancelDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonCreateCategory_Command(object sender, CommandEventArgs e)
        {
            var categoryTitle = this.TextBoxAddCategory.Text;

            if (!string.IsNullOrEmpty(categoryTitle))
            {
                var context = new ApplicationDbContext();
                var newCategory = new Category()
                {
                    Title = categoryTitle
                };

                try
                {
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("Category \"{0}\" created!", categoryTitle));
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name can no be empty!");
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonCancelCreateCategory_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonShowCreateCategory_Command(object sender, CommandEventArgs e)
        {
            this.PanelCreateCategory.Visible = true;
            this.LinkButtonShowCreateCategory.Visible = false;
        }

        protected void SaveEditedCategory_Command(object sender, CommandEventArgs e)
        {
            //Edit question
            var textBoxEditCategory = this.FormViewEditCategory.FindControl("TextBoxEditCategory") as TextBox;
            var categoryTitle = textBoxEditCategory.Text;
            var context = new ApplicationDbContext();
            var categoryId = Convert.ToInt32(e.CommandArgument);
            try
            {
                var category = context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                category.Title = categoryTitle;
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage(string.Format("Category \"{0}\" created!", categoryTitle));
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void CancelEditCategory_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void GridViewCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewCategories.PageIndex = e.NewPageIndex;
        }

        protected void GridViewCategories_Sorting(object sender, GridViewSortEventArgs e)
        {
            var context = new ApplicationDbContext();
            var sortedCategories = context.Categories.OrderBy(x => x.Title);
            this.GridViewCategories.DataSource = sortedCategories.ToList();
            this.GridViewCategories.DataBind();
        }
    }
}