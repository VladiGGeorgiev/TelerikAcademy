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
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var context = new ApplicationDbContext();
                var books = context.Books.Include("Category").ToList();
                var booksModels = books.Select(x => new BookModel()
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                });


                this.GridViewBooks.DataSource = booksModels;
                this.GridViewBooks.DataBind();
            }
        }

        protected void ButtonShowEditForm_Command(object sender, CommandEventArgs e)
        {
            this.FormViewDeleteBook.DataSource = null;
            this.FormViewDeleteBook.DataBind();
            this.LinkButtonShowCreateBookForm.Visible = false;

            var context = new ApplicationDbContext();
            var bookId = Convert.ToInt32(e.CommandArgument);
            var book = context.Books.Include("Category").Where(x => x.BookId == bookId);
            this.FormViewEditBook.DataSource = book.ToList();
            this.FormViewEditBook.DataBind();

            var categoryId = book.FirstOrDefault();
            var dropdownListEditCategories = this.FormViewEditBook.FindControl("DropDownListEditCategories") as DropDownList;
            dropdownListEditCategories.DataSource = context.Categories.ToList();
            dropdownListEditCategories.SelectedValue = categoryId.Category.CategoryId.ToString();
            dropdownListEditCategories.DataBind();
        }

        protected void SaveEditedBook_Command(object sender, CommandEventArgs e)
        {
            var textBoxEditCategory = this.FormViewEditBook.FindControl("TextBoxEditBookTitle") as TextBox;
            var title = textBoxEditCategory.Text;

            var textBoxAuthor = this.FormViewEditBook.FindControl("TextBoxEditBookAuthor") as TextBox;
            var author = textBoxAuthor.Text;

            var textBoxISBN = this.FormViewEditBook.FindControl("TextBoxEditBookISBN") as TextBox;
            var isbn = textBoxISBN.Text;

            var textBoxWebSite = this.FormViewEditBook.FindControl("TextBoxEditBookWebSite") as TextBox;
            var webSite = textBoxWebSite.Text;

            var textBoxDescription = this.FormViewEditBook.FindControl("TextBoxEditBookDescription") as TextBox;
            var description = textBoxDescription.Text;

            var categoryDropDownList = this.FormViewEditBook.FindControl("DropDownListEditCategories") as DropDownList;
            var category = categoryDropDownList.SelectedItem;
            var categoryId = Convert.ToInt32(category.Value);

            var context = new ApplicationDbContext();
            var dbCategory = context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (dbCategory != null)
            {
                var bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.FirstOrDefault(c => c.BookId == bookId);

                book.Title = title;
                book.Author = author;
                book.ISBN = isbn;
                book.WebSite = webSite;
                book.Description = description;
                book.Category = dbCategory;

                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("Category \"{0}\" edited!", title));
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Wrong category!");
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void CancelEditedBook_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ShowDeleteForm_Command(object sender, CommandEventArgs e)
        {
            this.FormViewEditBook.DataSource = null;
            this.FormViewEditBook.DataBind();
            this.LinkButtonShowCreateBookForm.Visible = false;

            var context = new ApplicationDbContext();
            var bookId = Convert.ToInt32(e.CommandArgument);
            var book = context.Books.Where(x => x.BookId == bookId);
            this.FormViewDeleteBook.DataSource = book.ToList();
            this.FormViewDeleteBook.DataBind();
        }

        protected void LinkButtonDeleteBook_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var bookId = Convert.ToInt32(e.CommandArgument);
            var book = context.Books.Include("Category").FirstOrDefault(x => x.BookId == bookId);
            if (book != null)
            {
                try
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("Book {0} removed!", book.Title));
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Can not remove book with id: " + bookId);
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonCancelDeleteBook_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonShowCreateBookForm_Command(object sender, CommandEventArgs e)
        {
            this.PanelCreateBook.Visible = true;
            this.LinkButtonShowCreateBookForm.Visible = false;

            var context = new ApplicationDbContext();
            var categories = context.Categories.OrderBy(c => c.Title).ToList();
            this.DropDownListCategories.DataSource = categories;
            this.DropDownListCategories.DataBind();
        }

        protected void LinkButtonCreateBook_Command(object sender, CommandEventArgs e)
        {
            var title = this.TextBoxAddBookTitle.Text;
            var author = TextBoxAddBookAuthor.Text;
            var isbn = TextBoxAddBookISBN.Text;
            var webSite = TextBoxAddBookWebSite.Text;
            var description = TextBoxAddBookDescription.Text;
            var category = DropDownListCategories.SelectedItem;
            var categoryId = Convert.ToInt32(category.Value);
            var context = new ApplicationDbContext();
            var dbCategory = context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (dbCategory != null)
            {
                var newBook = new Book() 
                {
                    Title = title,
                    Author = author,
                    ISBN = isbn,
                    WebSite = webSite,
                    Description = description,
                    Category = dbCategory
                };

                try
                {
                    context.Books.Add(newBook);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage(string.Format("Book \"{0}\" created", title));
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage(string.Format("There isn't category {0} in database", category.Text));
            }

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void LinkButtonCancelCreateBook_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void GridViewBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewBooks.PageIndex = e.NewPageIndex;
        }

        protected void GridViewBooks_Sorting(object sender, GridViewSortEventArgs e)
        {
            var context = new ApplicationDbContext();
            IEnumerable<BookModel> books = null;
            if (e.SortExpression == "Title")
            {
                books = context.Books.OrderBy(x => x.Title).Select(x => new BookModel()
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                });
            }
            else if (e.SortExpression == "Author")
            {
                books = context.Books.OrderBy(x => x.Author).Select(x => new BookModel()
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                });
            }
            else if (e.SortExpression == "ISBN")
            {
                books = context.Books.OrderBy(x => x.ISBN).Select(x => new BookModel()
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                });
            }
            else if (e.SortExpression == "WebSite")
            {
                books = context.Books.OrderBy(x => x.WebSite).Select(x => new BookModel()
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                });
            }
            else if (e.SortExpression == "WebSite")
            {
                books = context.Books.OrderBy(x => x.Category.Title).Select(x => new BookModel()
                {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                });
            }
            else if (e.SortExpression == "Category")
            {
                books = context.Books.Select(x => new BookModel() {
                    BookId = x.BookId,
                    Author = x.Author,
                    Category = x.Category.Title,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Title = x.Title,
                    WebSite = x.WebSite
                }).OrderBy(x => x.Category);
            }
            var sortedCategories = context.Categories.OrderBy(x => x.Title);
            this.GridViewBooks.DataSource = books.ToList();
            this.GridViewBooks.DataBind();
        }
    }
}