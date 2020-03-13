using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
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
