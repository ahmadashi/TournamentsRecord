using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface IPlayerViewModelUpdater : IViewModelUpdater<PlayerViewModel>, IViewModelDeleter<PlayerViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
