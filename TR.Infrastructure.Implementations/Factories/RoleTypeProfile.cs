using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
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
