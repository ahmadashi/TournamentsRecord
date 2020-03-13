using System.Collections.Generic;

namespace TR.Utilities.HttpClientWrapper.Options
{
    public class HttpConfigurationOptions
    {
        public IEnumerable<HttpClientConfigurationItem> HttpClients { get; set; }
    }
}