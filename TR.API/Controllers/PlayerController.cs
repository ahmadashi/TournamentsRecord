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
    public class PlayerController : BaseController
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerViewModelProvider _playerViewModelProvider;
        public PlayerController(ILogger<PlayerController> logger,
            IPlayerViewModelProvider playerViewModelProvider) : base(logger)
        {
            _logger = logger;
            _playerViewModelProvider = playerViewModelProvider;
            //_userViewModelProvider = PlayerViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET Player");

                var results = await _playerViewModelProvider.ByIdAsync(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpGet("GetByTeamId/{teamId}")]
        public async Task<ActionResult> GetByBookId(int teamId)
        {
            try
            {
                _logger.LogDebug("GET all Player for team");

                var results = await _playerViewModelProvider.ByIdAsync(teamId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
