using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
    public class TeamViewModel : BaseViewModel
    {
		public string TeamName { get; set; }
		public DateOnly FoundedYear { get; set; }
		public string City { get; set; }
		public List<BranchTeamViewModel> BranchTeam { get; set; } = new List<BranchTeamViewModel>();
		public List<PlayerTeamViewModel> PlayerTeam { get; set; } = new List<PlayerTeamViewModel>();
		public List<GameViewModel> Games { get; set; } = new List<GameViewModel>();
		public List<GameViewModel> HomeMatches { get; set; } = new List<GameViewModel>();
		public List<GameViewModel> AwayMatches { get; set; } = new List<GameViewModel>();
		public List<GameInfoViewModel> GameInfos { get; set; } = new List<GameInfoViewModel>();
	}
}
