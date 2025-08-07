using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
	public class StatusViewModel : BaseViewModel
	{
		public string StatusName { get; set; }

		public  List<GameInfoViewModel> GameInfos { get; set; } = new List<GameInfoViewModel>();
	}
}
