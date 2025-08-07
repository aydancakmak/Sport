using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
    public class BranchViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public  List<PlayerViewModel> Players { get; set; } = new List<PlayerViewModel>();  
        public  List<GameViewModel> Games { get; set; } = new List<GameViewModel>();
        public  List<BranchTeamViewModel> BranchTeam { get; set; } = new List<BranchTeamViewModel>();
        
    }
}
