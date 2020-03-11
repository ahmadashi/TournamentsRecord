using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IViewModelProviderByActive<TV>
    {
        Task<IEnumerable<TV>> ByActiveAsync(bool active);
    }
}
