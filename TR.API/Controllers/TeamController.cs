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
    public class TeamController : BaseController
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamViewModelProvider _teamViewModelProvider;
        public TeamController(ILogger<TeamController> logger,
            ITeamViewModelProvider teamViewModelProvider) : base(logger)
        {
            _logger = logger;
            _teamViewModelProvider = teamViewModelProvider;
            //_userViewModelProvider = TeamViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET all Team");

                var results = await _teamViewModelProvider.ByIdAsync(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpGet("GetByTournamentId/{tournamentId}")]
        public async Task<ActionResult> GetByTournamentId(int tournamentId)
        {
            try
            {
                _logger.LogDebug("GET all Team for user");

                var results = await _teamViewModelProvider.ByIdAsync(tournamentId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
