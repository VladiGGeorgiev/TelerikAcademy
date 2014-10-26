using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PractialExam.App.Models
{
    public class CommentModel
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "The content is required!")]
        public string Content { get; set; }
    }
}