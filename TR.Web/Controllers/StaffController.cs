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
    public class StaffController : BaseController
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        public StaffController(ILogger<StaffController> logger,
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
                var results = await _apiClient.GetAsync<IEnumerable<StaffViewModel>>($"Staff/{id}?");
                _logger.LogDebug($"GET all sports types for select");
                
                return Ok(results);                
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpGet("GetByTeamId/{teamId}")]
        public async Task<ActionResult> GetByTeamId(int teamId)
        {
            try
            {
                var results = await _apiClient.GetAsync<IEnumerable<StaffViewModel>>($"Staff/GetByTeamId/{teamId}?");
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

