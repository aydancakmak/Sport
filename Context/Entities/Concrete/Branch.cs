using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; } 
        public virtual ICollection<Game> Games { get; set; } 
        public virtual ICollection<BranchTeam> BranchTeam { get; set; } 
    }
}
