using System.Collections.Generic;
using System.Linq;

namespace TR.Infrastructure.Interfaces.Factories
{
    public interface IViewModelFactory<TViewModel, TDomain>
    {
        
        TViewModel For(TDomain value);

        TDomain Build(TViewModel value);
    }
}
