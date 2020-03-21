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
    //[Authorize]
    public class RoleTypeController : BaseController
    {
        private readonly ILogger<RoleTypeController> _logger;
        private readonly IRoleTypeViewModelProvider _roleTypeViewModelProvider;
        public RoleTypeController(ILogger<RoleTypeController> logger,
            IRoleTypeViewModelProvider roleTypeViewModelProvider) : base(logger)
        {
            _logger = logger;
            _roleTypeViewModelProvider = roleTypeViewModelProvider;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.LogDebug("GET all role types");

                var results = await _roleTypeViewModelProvider.ByAllAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
