using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
{
    internal class SportTypeProfile : Profile
    {
        public SportTypeProfile()
        {
            CreateMap<SportTypeViewModel, SportType>()
                .ReverseMap();
        }
    }
}
