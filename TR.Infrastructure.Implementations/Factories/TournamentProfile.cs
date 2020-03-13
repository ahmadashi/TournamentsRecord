using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
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
