using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, User>()
                .ReverseMap();
        }
    }
}
