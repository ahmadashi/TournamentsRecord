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
    public class TournamentTypeController : BaseController
    {
        private readonly ILogger<TournamentTypeController> _logger;
        private readonly ITournamentTypeViewModelProvider _tournamentTypeViewModelProvider;
        public TournamentTypeController(ILogger<TournamentTypeController> logger,
            ITournamentTypeViewModelProvider tournamentTypeViewModelProvider) : base(logger)
        {
            _logger = logger;
            _tournamentTypeViewModelProvider = tournamentTypeViewModelProvider;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.LogDebug("GET all Tournaments types");

                var results = await _tournamentTypeViewModelProvider.ByAllAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
