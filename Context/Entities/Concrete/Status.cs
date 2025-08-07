using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
	public class Status : BaseEntity
	{
        public string StatusName { get; set; }

		public virtual ICollection<GameInfo> GameInfos { get; set; } 
    }
}
