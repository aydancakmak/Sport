using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
	public class GameInfo : BaseEntity
	{
        public int GameId { get; set; }
        public Game Game { get; set; }
		public int TeamId { get; set; }
		public Team Team { get; set; }
		public bool IsHomeTeam { get; set; }
        public int StatusId { get; set; }
		public Status Status { get; set; }
        public byte Score { get; set; }
    }
}
