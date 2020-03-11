using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface ILogoViewModelUpdater : IViewModelUpdater<LogoViewModel>, IViewModelDeleter<LogoViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
