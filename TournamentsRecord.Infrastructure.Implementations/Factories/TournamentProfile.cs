using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
{
    internal class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<TournamentViewModel, Tournament>()
                .ReverseMap();
        }
    }
}
