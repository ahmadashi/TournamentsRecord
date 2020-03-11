using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface IViewModelDeleter<TV>
    {
        Task<TV> DeleteAsync(TV viewModel);
    }
}
