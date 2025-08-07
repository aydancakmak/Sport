namespace Sports.MVC.Models.Abstract
{
    public abstract class BaseViewModel
    {
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public bool IsDeleted { get; set; }

	}
}
