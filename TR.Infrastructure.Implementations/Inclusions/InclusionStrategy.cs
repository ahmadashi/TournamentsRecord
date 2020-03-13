using System;
using System.Linq;
using TR.Infrastructure.Interfaces.Inclusions;

namespace TR.Infrastructure.Implementations.Inclusions
{
    public class InclusionStrategy<T> : IInclusionStrategy<T>
    {
        public Func<IQueryable<T>, IQueryable<T>> InclusionFunc { get; set; }

        public InclusionStrategy() { }

        public InclusionStrategy(Func<IQueryable<T>, IQueryable<T>> inclusionAction)
        {
            InclusionFunc = inclusionAction;
        }
    }
}
