using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface IViewModelUpdater<TV>
    {
        Task<TV> AddOrUpdateAsync(TV viewModel);
    }
}
