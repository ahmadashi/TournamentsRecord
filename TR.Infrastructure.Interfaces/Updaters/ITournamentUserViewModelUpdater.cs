using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface ITournamentUserViewModelUpdater : IViewModelUpdater<TournamentUserViewModel>, IViewModelDeleter<TournamentUserViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
