using AutoMapper;
using Sports.MVC.Context.Entities.Concrete;
using Sports.MVC.Models.Concrete;

namespace Sports.MVC.MapperProfiles
{
	public class GameInfoProfile : Profile
	{
		public GameInfoProfile()
		{
			CreateMap<GameInfo, GameInfoViewModel>()
			.ReverseMap();
		}
	}
}
