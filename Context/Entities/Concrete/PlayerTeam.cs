using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
    public class PlayerTeam : BaseEntity
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
