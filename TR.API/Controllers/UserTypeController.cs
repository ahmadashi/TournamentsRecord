using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TR.Infrastructure.Interfaces.Providers;
using TR.Infrastructure.ViewModel;
using TR.Utilities.HttpClientWrapper;

namespace TR.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserTypeController : BaseController
    {
        private readonly ILogger<UserTypeController> _logger;
        private readonly IUserTypeViewModelProvider _userTypeViewModelProvider;
        public UserTypeController(ILogger<UserTypeController> logger,
            IUserTypeViewModelProvider userTypeViewModelProvider) : base(logger)
        {
            _logger = logger;
            _userTypeViewModelProvider = userTypeViewModelProvider;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.LogDebug("GET all Users types");

                var results = await _userTypeViewModelProvider.ByAllAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
