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
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserViewModelProvider _userViewModelProvider;
        public UserController(ILogger<UserController> logger,
            IUserViewModelProvider userViewModelProvider) : base(logger)
        {
            _logger = logger;
            _userViewModelProvider = userViewModelProvider;
            //_userViewModelProvider = UserViewModelProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug("GET all User");

                var results = await _userViewModelProvider.ByIdAsync(id);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        
    }
}
