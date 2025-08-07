using Sports.MVC.Context.Entities.Abstract;

namespace Sports.MVC.Context.Entities.Concrete
{
    public class Player : BaseEntity
    {
        public string PlayerName { get; set; }
        public string PlayerSurname { get; set; }
        public DateTime PlayerBirthDate { get; set; }
        public string Gender { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; } 
    }
}
