
namespace DevSocialMe.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        public virtual Skill SkillId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
