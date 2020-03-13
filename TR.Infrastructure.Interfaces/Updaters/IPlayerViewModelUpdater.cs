using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface IPlayerViewModelUpdater : IViewModelUpdater<PlayerViewModel>, IViewModelDeleter<PlayerViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
