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
    public class StaffController : BaseController
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IStaffViewModelProvider _staffViewModelProvider;
        public StaffController(ILogger<StaffController> logger,
            IStaffViewModelProvider staffViewModelProvider) : base(logger)
        {
            _logger = logger;
            _staffViewModelProvider = staffViewModelProvider;
            //_userViewModelProvider = StaffViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET all Staff");

                var results = await _staffViewModelProvider.ByIdAsync(id);

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
                _logger.LogDebug("GET all Staff for team");

                var results = await _staffViewModelProvider.ByIdAsync(teamId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


    }
}
