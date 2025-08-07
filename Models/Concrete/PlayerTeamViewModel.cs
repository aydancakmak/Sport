using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Abstract;

namespace Sports.MVC.Models.Concrete
{
    public class PlayerTeamViewModel : BaseViewModel
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
