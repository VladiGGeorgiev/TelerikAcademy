using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FbmMobileApp.ViewModels
{
    public class StudioDetailsModel
    {
        public StudioDetailsModel()
        {
            this.Comments = new HashSet<CommentModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public string Picture { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public int Rating { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}