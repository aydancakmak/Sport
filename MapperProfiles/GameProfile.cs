using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class GameProfile : Profile
	{
		public GameProfile()
		{
			CreateMap<Game, GameViewModel>()
			.ReverseMap();
		}
	}
}
