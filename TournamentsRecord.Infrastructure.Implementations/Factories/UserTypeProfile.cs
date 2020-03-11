using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
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
