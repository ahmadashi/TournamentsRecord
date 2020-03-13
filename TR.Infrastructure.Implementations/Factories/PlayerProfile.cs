using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
{
    internal class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerViewModel, Player>()
                .ReverseMap();
        }
    }
}
