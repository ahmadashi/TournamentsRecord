using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
{
    internal class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserTypeViewModel, UserType>()
                .ReverseMap();
        }
    }
}
