using System;
using System.Linq;
using TournamentsRecord.Infrastructure.Interfaces.Inclusions;

namespace TournamentsRecord.Infrastructure.Implementations.Inclusions
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
