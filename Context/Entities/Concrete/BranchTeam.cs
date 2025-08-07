using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
    public class BranchTeam : BaseEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}
