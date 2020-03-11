using AutoMapper;
using Vprc.Domain;

namespace Vprc.Infrastructure.ViewModel.Factory.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentViewModel, Student>()
                .ForMember(x => x.ChallengeYear, y => y.Ignore())
                .ForMember(x => x.School, y => y.Ignore())
                .ForMember(x => x.StudentYearLevel, y => y.Ignore())
                .ForMember(x => x.StudentBooks, y => y.Ignore())
                .ForMember(x => x.Avatar, y => y.Ignore())
                .ForMember(x => x.SchoolGroup, y => y.Ignore())
                .ForMember(x => x.FullName, y => y.MapFrom(src => $"{src.GivenName} {src.FamilyName}"))
                .ForMember(x => x.Campus, y => y.Ignore())
                .ForMember(x => x.PreviousSchool, y => y.Ignore())
                .ReverseMap();

            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.TotalBooks, y => y.Ignore())
                .ForMember(x => x.ChoiceBooks, y => y.Ignore())
                .ForMember(x => x.ChallengeBooks, y => y.Ignore())
                .ForMember(x => x.TargetBookQuota, y => y.Ignore())
                .ForMember(x => x.BookProgress, y => y.Ignore())
                .ForMember(x => x.BooksToVerify, y => y.Ignore())
                .ForMember(x => x.FullName, y => y.MapFrom(src => $"{src.GivenName} {src.FamilyName}"))
                .ForMember(x => x.SchoolGroupName,
                    y => y.MapFrom(s => s.SchoolGroup == null ? null : s.SchoolGroup.SchoolGroupName))
                .ForMember(x => x.LearningCoordinatorId,
                    y => y.MapFrom(s => s.SchoolGroup == null || s.SchoolGroup.User == null ? 0 : s.SchoolGroup.UserId))
                .ForMember(x => x.LearningCoordinatorIsActive,
                    y => y.MapFrom(s =>
                        s.SchoolGroup != null && s.SchoolGroup.User != null && s.SchoolGroup.User.IsActive))
                .ForMember(x => x.CampusName, y => y.MapFrom(s => s.Campus == null ? null : s.Campus.Name))
                .ForMember(x => x.LearningCoordinatorName,
                    y => y.MapFrom(
                        s => s.SchoolGroup == null || s.SchoolGroup.User == null
                            ? null
                            : $"{s.SchoolGroup.User.GivenName} {s.SchoolGroup.User.FamilyName}"))
                .ForMember(x => x.StudentYearLevelDescription,
                    y => y.MapFrom(s => s.StudentYearLevel == null ? null : s.StudentYearLevel.Description))
                .ForMember(x => x.StudentYearLevelShortName,
                    y => y.MapFrom(s => s.StudentYearLevel == null ? null : s.StudentYearLevel.ShortName))
                .ForMember(x => x.RoleType, y => y.MapFrom((src => (int)src.RoleType)))
                .ForMember(x => x.SchoolName,
                    y => y.MapFrom(s => s.School == null ? null : s.School.SchoolName))

                .ForMember(x => x.PreviousSchoolName,
                    y => y.MapFrom(s => s.PreviousSchool == null ? null : s.PreviousSchool.SchoolName));

        }
    }
}