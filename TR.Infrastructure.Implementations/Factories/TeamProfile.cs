using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
{
    internal class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamViewModel, Team>()
                .ReverseMap();
        }
    }
}
