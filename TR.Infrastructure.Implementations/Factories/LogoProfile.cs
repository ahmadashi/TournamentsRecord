using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
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
