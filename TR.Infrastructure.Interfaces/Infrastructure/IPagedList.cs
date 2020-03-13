using System.Collections.Generic;

namespace TR.Infrastructure.Interfaces.Infrastructure
{
    public class IPagedList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public long Count { get; set; }
    }
}
