using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IViewModelProviderById<TV>
    {
        Task<TV> ByIdAsync(int id);
    }
}
