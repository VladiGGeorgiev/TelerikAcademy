using System.ComponentModel.DataAnnotations;
using PracticalExam.Models;

namespace PractialExam.App.Models
{
    public class AddTicketModel
    {
        [Required(ErrorMessage = "The Category is required!")]
        public int Category { get; set; }

        [Required(ErrorMessage = "The title is required!")]
        [ShouldNotContainBug(ErrorMessage = "Title should not contains bug!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The title is required!")]
        public string Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        [ShouldNotContainHtml]
        public string Description { get; set; }
    }
}