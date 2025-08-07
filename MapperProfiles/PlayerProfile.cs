using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class PlayerProfile : Profile
	{
		public PlayerProfile()
		{
			CreateMap<Player, PlayerViewModel>()
				.ReverseMap();
		}
	}
}

