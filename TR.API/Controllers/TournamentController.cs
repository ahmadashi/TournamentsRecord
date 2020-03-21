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
    public class TournamentController : BaseController
    {
        private readonly ILogger<TournamentController> _logger;
        private readonly ITournamentViewModelProvider _tournamentViewModelProvider;
        public TournamentController(ILogger<TournamentController> logger,
            ITournamentViewModelProvider tournamentViewModelProvider) : base(logger)
        {
            _logger = logger;
            _tournamentViewModelProvider = tournamentViewModelProvider;
            //_userViewModelProvider = tournamentViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET all tournament");

                var results = await _tournamentViewModelProvider.ByIdAsync(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<ActionResult> GetByBookId(int userId)
        {
            try
            {
                _logger.LogDebug("GET all tournament for user");

                var results = await _tournamentViewModelProvider.ByIdAsync(userId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
