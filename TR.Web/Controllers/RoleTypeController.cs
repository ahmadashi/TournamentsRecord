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
    public class RoleTypeController : BaseController
    {
        private readonly ILogger<RoleTypeController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        public RoleTypeController(ILogger<RoleTypeController> logger,
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

                var results = _apiClient.GetAsync<IEnumerable<RoleTypeViewModel>>("RoleType?");
                _logger.LogDebug($"GET all Roles types for select");
                var result = await results;

                var RoleTypes = result
                    .Select(s => new SelectOptionsViewModel { Id = s.RoleTypeId, Text = s.Description })
                    .ToList();
                //schoolSectors.Insert(0, new SelectOptionsViewModel() { Id = 0, Text = "All" });

                return Ok(RoleTypes);                
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }   


    }
}
