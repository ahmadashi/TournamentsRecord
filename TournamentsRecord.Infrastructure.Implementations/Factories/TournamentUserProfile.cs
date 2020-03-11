using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
{
    internal class TournamentUserProfile : Profile
    {
        public TournamentUserProfile()
        {
            CreateMap<TournamentUserViewModel, TournamentUser>()
                .ReverseMap();
        }
    }
}
