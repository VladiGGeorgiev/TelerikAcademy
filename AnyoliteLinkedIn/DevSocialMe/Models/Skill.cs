using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevSocialMe.Models
{
    public class Skill
    {
        public Skill()
        {
            this.Owners = new HashSet<ApplicationUser>();
            this.Votes = new HashSet<Vote>();
        }

        public virtual ICollection<Vote> Votes { get; set; }

        public int SkillId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Owners { get; set; }
    }
}
