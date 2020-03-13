using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface IUserViewModelUpdater : IViewModelUpdater<UserViewModel>, IViewModelDeleter<UserViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
