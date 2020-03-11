using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IViewModelProviderById<TV>
    {
        Task<TV> ByIdAsync(int id);
    }
}
