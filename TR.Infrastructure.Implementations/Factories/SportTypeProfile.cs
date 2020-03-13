using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
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
