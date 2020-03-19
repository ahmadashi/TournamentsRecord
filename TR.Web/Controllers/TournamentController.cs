using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TR.Infrastructure.ViewModel;
using TR.Utilities.HttpClientWrapper;
using TR.Web.ViewModels;

namespace TR.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TournamentController : BaseController
    {
        private readonly ILogger<TournamentController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        public TournamentController(ILogger<TournamentController> logger,
            IHttpClientWrapper httpClientWrapper) : base(logger)
        {
            _logger = logger;
            _apiClient = httpClientWrapper;
            _apiClient.setClientKey("API");
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _apiClient.GetAsync<IEnumerable<TournamentViewModel>>($"Tournament/{id}?");
                _logger.LogDebug($"GET all sports types for select");
                
                return Ok(results);                
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }   


    }
}
