using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticalExam.Models;

namespace PractialExam.App.ViewModels
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; } //No html allowed

        public string Category { get; set; }

        public string Author { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }
    }
}