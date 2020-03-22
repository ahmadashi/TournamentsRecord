using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TR.Infrastructure.ViewModel;
using TR.Utilities.HttpClientWrapper;
using TR.Utilities.Serialization;
using TR.Web.ViewModels;




namespace TR.Web.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class TournamentController : BaseController
    {
        private readonly ILogger<TournamentController> _logger;
        private readonly IHttpClientWrapper _apiClient;
        protected readonly ISerializer _serializer;

        public TournamentController(ILogger<TournamentController> logger,
            IHttpClientWrapper httpClientWrapper,
            ISerializer serializer) : base(logger)
        {
            _logger = logger;
            _apiClient = httpClientWrapper;
            _apiClient.setClientKey("API");
            _serializer = serializer;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _apiClient.GetAsync<IEnumerable<TournamentViewModel>>($"Tournament/{id}?");
                _logger.LogDebug($"GET all sports types for select");
                
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
                _logger.LogDebug("GET all tournament for user");

                var results = await _apiClient.GetAsync<IEnumerable<TournamentViewModel>>($"tournament/GetByUserId/{userId}?");

                return Ok(results);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }


        [HttpPost]
        [Route("Update")]
        //[Authorize(Policy = nameof(MinimumRoleType.LearningCoOrdinator))]
        public async Task<IActionResult> Update([FromBody] TournamentViewModel tournament)
        {
            try
            {
                ApplyAudits(tournament, u => u.TournamentId);

                _logger.LogDebug($"Update tournament - ID : {tournament.TournamentId}");                
                
                var response = await _apiClient
                    .PostAsync<TournamentViewModel>("tournament/Update", _serializer.ToJsonStringContent(tournament));
                                               
                return Json(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return HandleUnauthorizedException(ex);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }

        [HttpPost]
        [Route("Add")]
        //[Authorize(Policy = nameof(MinimumRoleType.LearningCoOrdinator))]
        public async Task<IActionResult> Post([FromBody] TournamentViewModel tournament)
        {
            try
            {
                ApplyAudits(tournament, u => u.TournamentId);
                           
                _logger.LogDebug($"Update tournament - ID : {tournament.TournamentId}");
                            
                var response = await _apiClient
                    .PostAsync<UserViewModel>("tournament/Add", _serializer.ToJsonStringContent(tournament));

                return Json(response);
            }
            catch (Exception ex)
            {
                return HandleSpecificException(ex);
            }
        }



    }
}
