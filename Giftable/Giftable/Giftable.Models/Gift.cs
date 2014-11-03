using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftable.Models
{
    public class Gift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public User SuggestedBy { get; set; }

        public User SuggestedFor { get; set; }

        public bool Bought { get; set; }

        public bool Checked { get; set; }

        public bool Seen { get; set; }
    }
}
