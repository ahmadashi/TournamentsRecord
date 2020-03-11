using System.Collections.Generic;

namespace TournamentsRecord.Utilities.HttpClientWrapper.Options
{
    public class HttpConfigurationOptions
    {
        public IEnumerable<HttpClientConfigurationItem> HttpClients { get; set; }
    }
}