using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class StatusProfile : Profile
	{
		public StatusProfile()
		{
			CreateMap<Status, StatusViewModel>()
			.ReverseMap();
		}
	}
}
