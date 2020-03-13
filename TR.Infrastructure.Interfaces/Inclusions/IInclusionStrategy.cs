using System;
using System.Linq;

namespace TR.Infrastructure.Interfaces.Inclusions
{
    public interface IInclusionStrategy<T>
    {
        Func<IQueryable<T>, IQueryable<T>> InclusionFunc { get; set; }
    }
}
