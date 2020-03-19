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
    public class UserTypeController : BaseController
    {
        private readonly ILogger<UserTypeController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        public UserTypeController(ILogger<UserTypeController> logger,
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

                var results = _apiClient.GetAsync<IEnumerable<UserTypeViewModel>>("UserType?");
                _logger.LogDebug($"GET all Users types for select");
                var result = await results;

                var UserTypes = result
                    .Select(s => new SelectOptionsViewModel { Id = s.UserTypeId, Text = s.Description })
                    .ToList();
                //schoolSectors.Insert(0, new SelectOptionsViewModel() { Id = 0, Text = "All" });

                return Ok(UserTypes);                
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }   


    }
}
