using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
{
    internal class TournamentTypeProfile : Profile
    {
        public TournamentTypeProfile()
        {
            CreateMap<TournamentTypeViewModel, TournamentType>()
                .ReverseMap();
        }
    }
}
