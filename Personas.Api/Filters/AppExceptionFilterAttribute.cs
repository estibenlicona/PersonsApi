using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Persons.Domain.Exceptions;
using System.Net;

namespace Persons.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<AppExceptionFilterAttribute> _Logger;
        private readonly IConfiguration _Configuration;

        public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger, IConfiguration configuration)
        {
            _Logger = logger;
            _Configuration = configuration;
        }


        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var message = context.Exception.Message;
            var type = "{Type}";

            if (!(context.Exception is AppException))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _Logger.LogError(context.Exception, $"{context.Exception.Message}-{type}", _Configuration.GetSection("NameExceptionSystem").GetValue<string>("Type"));
            }
            else
            {

                _Logger.LogError(context.Exception, $"{context.Exception.Message}-{type}", _Configuration.GetSection("NameExceptionDomain").GetValue<string>("Type"));
            }

            var msg = new
            {
                message,
                ExceptionType = context.Exception.GetType().ToString()
            };

            context.Result = new ObjectResult(msg);
        }
    }
}
