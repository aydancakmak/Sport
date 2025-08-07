using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
    public class GameViewModel : BaseViewModel
    {
		public int HomeTeamId { get; set; }
		public int AwayTeamId { get; set; }
		public int BranchId { get; set; }
		public string GamePlace { get; set; }
		public DateTime GameDate { get; set; }
		public byte Duration { get; set; }
		public Branch Branch { get; set; }
		public Team HomeTeam { get; set; }
		public Team AwayTeam { get; set; }
		public List<GameInfoViewModel> GameInfos { get; set; } = new List<GameInfoViewModel>();

	}
}
