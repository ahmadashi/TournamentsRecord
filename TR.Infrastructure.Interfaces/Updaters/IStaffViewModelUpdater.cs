using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface IStaffViewModelUpdater : IViewModelUpdater<StaffViewModel>, IViewModelDeleter<StaffViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
