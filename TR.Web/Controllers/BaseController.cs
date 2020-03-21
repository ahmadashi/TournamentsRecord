using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TR.DAL.Exception;
using TR.Infrastructure.ViewModel;
using TR.Utilities.ExceptionHandling;
//using TR.Utilities.ExceptionHandling.Exceptions;
//using Vprc.Domain.Exception;

namespace TR.Web.Controllers
{
    public class BaseController : Controller
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

        protected void ApplyAudits<T>(T viewModel, Func<T, int> idProperty) where T : AuditedObjectViewModel
        {
            //var userName = GetUserName() ?? "SYSTEM";

            //if (userName.Length > 25)
            //{
            //    userName = GetUserIdFromClaim().ToString();
            //}
            //ashi update this username
            string userName = "ashi";
            if (idProperty(viewModel) == 0)
            {
                viewModel.CreatedDate = DateTime.Now;
                viewModel.CreatedBy = userName;
            }

            viewModel.ModifyDate = DateTime.Now;
            viewModel.ModifyBy = userName;
        }

    }
}
