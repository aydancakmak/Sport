using Sports.MVC.Context.Entities.Abstract;
using System.Text.RegularExpressions;

namespace Sports.MVC.Context.Entities.Concrete
{
    public class Team : BaseEntity
    {
        public string TeamName { get; set; }
        public DateOnly FoundedYear { get; set; }
        public string City { get; set; }
        public virtual ICollection<BranchTeam> BranchTeam { get; set; } 
        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; } 
        public virtual ICollection<Game> Games { get; set; } 
        public virtual ICollection<Game> HomeMatches { get; set; } 
        public virtual ICollection<Game> AwayMatches { get; set; } 
        public virtual ICollection<GameInfo> GameInfos { get; set; } 
        
    }
}
