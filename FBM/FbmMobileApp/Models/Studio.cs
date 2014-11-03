using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FbmMobileApp.Models
{
    public class Studio
    {
        public Studio()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public string Picture { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        [DataType("decimal")]
        public decimal Longitude { get; set; }

        [DataType("decimal")]
        public decimal Latitude { get; set; }

        public int Rating { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}