using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api
{
    /// <summary>
    /// Custom exception filter for the API
    /// </summary>
    public class TimerExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Action executed on exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            // Adding the exception into log
            Logger.LogError(ex);

            // Setting the status code of response to 500 ( Internal server error)
            context.HttpContext.Response.StatusCode = 500;

            base.OnException(context);
        }
    }
}
