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
    public class TournamentUserController : BaseController
    {
        private readonly ILogger<TournamentUserController> _logger;
        private readonly ITournamentUserViewModelProvider _tournamentUserViewModelProvider;
        public TournamentUserController(ILogger<TournamentUserController> logger,
            ITournamentUserViewModelProvider tournamentUserViewModelProvider) : base(logger)
        {
            _logger = logger;
            _tournamentUserViewModelProvider = tournamentUserViewModelProvider;
            //_userViewModelProvider = TournamentUserViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET all TournamentUser");

                var results = await _tournamentUserViewModelProvider.ByIdAsync(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
            try
            {
                _logger.LogDebug("GET all TournamentUser for user");

                var results = await _tournamentUserViewModelProvider.ByIdAsync(userId);

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
                _logger.LogDebug("GET all TournamentUser for user");

                var results = await _tournamentUserViewModelProvider.ByIdAsync(tournamentId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
