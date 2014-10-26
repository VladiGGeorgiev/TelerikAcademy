using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PractialExam.App.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int CommentsNumber { get; set; }
    }
}