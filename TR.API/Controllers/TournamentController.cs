using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TR.DAL.Exception;
using TR.Infrastructure.Interfaces.Providers;
using TR.Infrastructure.Interfaces.Updaters;
using TR.Infrastructure.ViewModel;
using TR.Utilities.ExceptionHandling;
using TR.Utilities.HttpClientWrapper;

namespace TR.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class TournamentController : BaseController
    {
        private readonly ILogger<TournamentController> _logger;
        private readonly ITournamentViewModelProvider _tournamentViewModelProvider;
        private readonly ITournamentViewModelUpdater _tournamentViewModelUpdater;
        private readonly IAuditTrailUpdater _auditTrailUpdater;
        public TournamentController(ILogger<TournamentController> logger,
            ITournamentViewModelProvider tournamentViewModelProvider,
            ITournamentViewModelUpdater tournamentViewModelUpdater,
            IAuditTrailUpdater auditTrailUpdater) : base(logger)
        {
            _logger = logger;
            _tournamentViewModelProvider = tournamentViewModelProvider;
            _tournamentViewModelUpdater = tournamentViewModelUpdater;
            _auditTrailUpdater = auditTrailUpdater;
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




        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] TournamentViewModel tournament)
        {
            try
            {
                _logger.LogDebug($"add new tournament {tournament.Name}");

                var results = await _tournamentViewModelUpdater.AddOrUpdateAsync(tournament);

                await _auditTrailUpdater.RegisterUpdateAsync(tournament);

                return Ok(results);
            }
            catch (DuplicateKeyException ex)
            {
                return HandleUserDuplicateException(ex);
            }
            catch (UserValidationException ex)
            {
                return HandleUserValidationException(ex);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] TournamentViewModel tournament)
        {
            try
            {
                _logger.LogDebug($"add new tournament {tournament.Name}");
                                
                //_userValidator.Validate(user);

                var results = await _tournamentViewModelUpdater.AddOrUpdateAsync(tournament);

                await _auditTrailUpdater.RegisterUpdateAsync(tournament);

                return Ok(results);
            }
            catch (DuplicateKeyException ex)
            {
                return HandleUserDuplicateException(ex);
            }
            catch (UserValidationException ex)
            {
                return HandleUserValidationException(ex);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromBody] TournamentViewModel tournament)
        {
            try
            {
                _logger.LogDebug($"add new tournament {tournament.Name}");

                //_userValidator.Validate(user);

                var results = await _tournamentViewModelUpdater.DeleteAsync(tournament);
                               
                await _auditTrailUpdater.RegisterDeletionAsync(tournament);

                return Ok(results);
            }
            catch (UserValidationException ex)
            {
                return HandleUserValidationException(ex);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
