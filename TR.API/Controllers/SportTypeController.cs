using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TR.Infrastructure.Interfaces.Providers;
//using TR.Infrastructure.ViewModel;
//using TR.Utilities.HttpClientWrapper;

namespace TR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   //[Authorize]
    public class SportTypeController : BaseController
    {
        private readonly ILogger<SportTypeController> _logger;
        private readonly ISportTypeViewModelProvider _sportTypeViewModelProvider;
        public SportTypeController(ILogger<SportTypeController> logger,
            ISportTypeViewModelProvider sportTypeViewModelProvider) : base(logger)
        {
            _logger = logger;
            _sportTypeViewModelProvider = sportTypeViewModelProvider;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.LogDebug("GET all sports types");

                var results = await _sportTypeViewModelProvider.ByAllAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
