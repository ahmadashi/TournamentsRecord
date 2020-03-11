using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
{
    internal class RoleTypeProfile : Profile
    {
        public RoleTypeProfile()
        {
            CreateMap<RoleTypeViewModel, RoleType>()
                .ReverseMap();
        }
    }
}
