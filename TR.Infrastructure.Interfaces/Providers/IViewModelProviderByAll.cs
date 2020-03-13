using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IViewModelProviderByAll<TV>
    {
        Task<IEnumerable<TV>> ByAllAsync();
    }
}
