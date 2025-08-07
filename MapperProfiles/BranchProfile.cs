using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class BranchProfile : Profile
	{
		public BranchProfile()
		{
			CreateMap<Branch, BranchViewModel>()
			.ReverseMap();
		}
	}
}
