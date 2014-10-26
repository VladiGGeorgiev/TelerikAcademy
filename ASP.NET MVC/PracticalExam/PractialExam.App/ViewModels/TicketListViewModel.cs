using PracticalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PractialExam.App.ViewModels
{
    public class TicketListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public Priority PriorityType { get; set; }

        public string Priority
        {
            get
            {
                return this.PriorityType.ToString();
            }
        }
    }
}