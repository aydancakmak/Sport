using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
    public class PlayerViewModel : BaseViewModel
    {
		public string PlayerName { get; set; }
		public string PlayerSurname { get; set; }
		public DateTime PlayerBirthDate { get; set; }
		public string Gender { get; set; }
		public int BranchId { get; set; }
		public Branch Branch { get; set; }
		public  List<PlayerTeamViewModel> PlayerTeam { get; set; } = new List<PlayerTeamViewModel>();

	}
}
