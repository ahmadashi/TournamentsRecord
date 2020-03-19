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
    public class LogoController : BaseController
    {
        private readonly ILogger<LogoController> _logger;
        private readonly ILogoViewModelProvider _logoViewModelProvider;
        public LogoController(ILogger<LogoController> logger,
            ILogoViewModelProvider logoViewModelProvider) : base(logger)
        {
            _logger = logger;
            _logoViewModelProvider = logoViewModelProvider;
            //_userViewModelProvider = LogoViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET Logo");

                var results = await _logoViewModelProvider.ByIdAsync(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.LogDebug("GET Logo");

                var results = await _logoViewModelProvider.ByAllAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

      


    }
}
