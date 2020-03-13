using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
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
