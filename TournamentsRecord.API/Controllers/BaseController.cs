using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TournamentsRecord.DAL.Exception;
using TournamentsRecord.Utilities.ExceptionHandling;
//using TournamentsRecord.Utilities.ExceptionHandling.Exceptions;
//using Vprc.Domain.Exception;

namespace TournamentsRecord.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> Logger;

        public BaseController(ILogger<BaseController> logger)
        {
            Logger = logger;
        }

        protected ActionResult HandleGenericException(Exception ex)
        {
            Logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        protected ActionResult HandleSpecificException(Exception ex)
        {
            Logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new Exception(ex.Message));
        }

        protected ActionResult HandleUnauthorizedException(UnauthorizedAccessException ex)
        {
            Logger.LogError(ex.Message);
            return new UnauthorizedResult();
        }

        protected ActionResult HandleUserDuplicateException(DuplicateKeyException ex)
        {
            Logger.LogError(ex.Message);
            return Conflict();
        }

        protected ActionResult HandleUserValidationException(UserValidationException ex)
        {
            Logger.LogError(ex.Message);
            return BadRequest();
        }
        protected ActionResult HandleUnavailableException(Exception ex)
        {
            Logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status503ServiceUnavailable, new Exception(ex.Message));
        }

    }
}
