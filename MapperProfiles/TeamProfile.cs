using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class TeamProfile : Profile
	{
		public TeamProfile()
		{
			CreateMap<Team, TeamViewModel>()
				.ReverseMap();	
		}
	}
}
