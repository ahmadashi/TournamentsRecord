using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
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
