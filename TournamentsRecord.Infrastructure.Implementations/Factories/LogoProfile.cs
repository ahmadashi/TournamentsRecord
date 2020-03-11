using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
{
    internal class LogoProfile : Profile
    {
        public LogoProfile()
        {
            CreateMap<LogoViewModel, Logo>()
                .ReverseMap();
        }
    }
}
