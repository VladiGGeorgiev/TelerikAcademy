namespace Forum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        public virtual Post Post { get; set; }
    }
}
