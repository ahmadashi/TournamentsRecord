using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
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
