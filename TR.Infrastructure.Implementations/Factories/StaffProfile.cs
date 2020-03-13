using AutoMapper;
using TR.DAL.Models;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Factory
{
    internal class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffViewModel, Staff>()
                .ReverseMap();
        }
    }
}
