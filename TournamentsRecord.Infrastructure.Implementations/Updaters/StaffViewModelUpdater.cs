using TournamentsRecord.DAL.Interfaces.Repositories;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.Interfaces.Factories;
using TournamentsRecord.Infrastructure.Interfaces.Repositories;
using TournamentsRecord.Infrastructure.Interfaces.Updaters;
using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace TournamentsRecord.Infrastructure.Implementations.Updaters
{
    public class StaffViewModelUpdater : IStaffViewModelUpdater
    {
        private readonly IViewModelFactory<Staff, StaffViewModel> _StaffViewModelFactory;
        private readonly IRepository<Staff> _StaffRepository;
        private readonly IReadOnlyRespository<StaffViewModel> _StaffUpdateRepository;

        public StaffViewModelUpdater(
            IViewModelFactory<Staff, StaffViewModel> StaffViewModelFactory,            
            IRepository<Staff> StaffRepository,
            IReadOnlyRespository<StaffViewModel> StaffUpdateRepository
            )
        {
            _StaffViewModelFactory = StaffViewModelFactory;            
            _StaffRepository = StaffRepository;
            _StaffUpdateRepository = StaffUpdateRepository;
        }

        public async Task<StaffViewModel> AddOrUpdateAsync(StaffViewModel Staff)
        {
            var dbStaff = await _StaffRepository.AddOrUpdateAsync(_StaffViewModelFactory.For(Staff));

            Staff.StaffId = dbStaff.StaffId;

            return Staff;
        }

        public async Task<StaffViewModel> DeleteAsync(StaffViewModel Staff)
        {
            var dbStaff = await _StaffRepository.DeleteAsync(_StaffViewModelFactory.For(Staff));

            Staff.StaffId = dbStaff.StaffId;

            return Staff;
        }

        //public async Task<StaffViewModel> MoveStaffToNewSchoolAsync(StaffViewModel Staff, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@StaffId", Staff.StaffId),
        //        new SqlParameter("@OldSchoolId", Staff.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _StaffUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMoveStaffToNewSchool]", parameters);

        //    Staff.SchoolId = newSchoolId;

        //    return Staff;
        //}

        //public async Task AddRangeAsync(ICollection<StaffViewModel> StaffsViewModels)
        //{
        //    var Staffs = new List<Staff>();

        //    foreach (var StaffViewModel in StaffsViewModels)
        //    {
        //        var Staff = _StaffViewModelFactory.For(StaffViewModel);

        //        Staffs.Add(Staff);
        //    }

        //    await _StaffRepository.AddRangeAsync(Staffs);
        //}


    }
}
