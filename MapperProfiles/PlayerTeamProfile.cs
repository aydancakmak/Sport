using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class PlayerTeamProfile : Profile
	{
		public PlayerTeamProfile()
		{
			CreateMap<PlayerTeam, PlayerTeamViewModel>()
			.ReverseMap();
		}
	}
}
