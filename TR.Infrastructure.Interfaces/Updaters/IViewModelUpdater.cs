using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface IViewModelUpdater<TV>
    {
        Task<TV> AddOrUpdateAsync(TV viewModel);
    }
}
