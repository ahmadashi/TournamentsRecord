using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface IUserTypeViewModelUpdater : IViewModelUpdater<UserTypeViewModel>, IViewModelDeleter<UserTypeViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
