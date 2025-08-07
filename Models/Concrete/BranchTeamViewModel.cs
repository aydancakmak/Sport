using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
    public class BranchTeamViewModel : BaseViewModel
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
