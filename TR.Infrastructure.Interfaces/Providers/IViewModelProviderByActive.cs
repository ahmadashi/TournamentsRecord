using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IViewModelProviderByActive<TV>
    {
        Task<IEnumerable<TV>> ByActiveAsync(bool active);
    }
}
