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
    //[Authorize]
    public class TournamentUserController : BaseController
    {
        private readonly ILogger<TournamentUserController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        public TournamentUserController(ILogger<TournamentUserController> logger,
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
                var results = await _apiClient.GetAsync<IEnumerable<TournamentUserViewModel>>($"TournamentUser/{id}?");
                _logger.LogDebug($"GET all sports types for select");
                
                return Ok(results);                
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


        [HttpGet("GetByUserId/{userId}")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
            try
            {
                var results = await _apiClient.GetAsync<IEnumerable<TournamentUserViewModel>>($"TournamentUser/GetByUserId/{userId}?");
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
