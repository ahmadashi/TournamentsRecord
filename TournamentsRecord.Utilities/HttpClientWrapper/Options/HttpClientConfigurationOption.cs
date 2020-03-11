﻿using System.Collections.Generic;

namespace TournamentsRecord.Utilities.HttpClientWrapper.Options
{
    public class HttpClientConfigurationOption
    {
        public string BaseUrl { get; set; }
        public IEnumerable<HttpClientPolicyConfiguration> Policies { get; set; }
    }
}