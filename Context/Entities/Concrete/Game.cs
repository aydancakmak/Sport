using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
    public class Game : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId  { get; set; }
        public int BranchId { get; set; }
        public string GamePlace { get; set; }
        public DateTime GameDate  { get; set; }
        public byte Duration { get; set; }
        public Branch Branch { get; set; }
        public Team HomeTeam { get; set; } 
        public Team AwayTeam { get; set; }

        public virtual ICollection<GameInfo> GameInfos { get; set; } 
       
    }
}
