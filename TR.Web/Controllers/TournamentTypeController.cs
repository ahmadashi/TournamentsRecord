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
    public class TournamentTypeController : BaseController
    {
        private readonly ILogger<TournamentTypeController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        public TournamentTypeController(ILogger<TournamentTypeController> logger,
            IHttpClientWrapper httpClientWrapper) : base(logger)
        {
            _logger = logger;
            _apiClient = httpClientWrapper;
            _apiClient.setClientKey("API");
        }

        [HttpGet]
        [Route("Get")]        
        public async Task<IActionResult> Get()
        {
            try
            {

                var results = _apiClient.GetAsync<IEnumerable<TournamentTypeViewModel>>("TournamentType?");
                _logger.LogDebug($"GET all Tournaments types for select");
                var result = await results;

                var TournamentTypes = result
                    .Select(s => new SelectOptionsViewModel { Id = s.TournamentTypeId, Text = s.Description })
                    .ToList();
                //schoolSectors.Insert(0, new SelectOptionsViewModel() { Id = 0, Text = "All" });

                return Ok(TournamentTypes);                
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }   


    }
}
