using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface IViewModelDeleter<TV>
    {
        Task<TV> DeleteAsync(TV viewModel);
    }
}
