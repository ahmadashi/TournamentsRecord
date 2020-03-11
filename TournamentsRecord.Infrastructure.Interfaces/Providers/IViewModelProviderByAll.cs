using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IViewModelProviderByAll<TV>
    {
        Task<IEnumerable<TV>> ByAllAsync();
    }
}
