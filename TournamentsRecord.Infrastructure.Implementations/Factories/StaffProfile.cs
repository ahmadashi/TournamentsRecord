using AutoMapper;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.DAL.Factory
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
