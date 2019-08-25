using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Api.BL;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoggerController : BaseApiController
	{

        /// <summary>
        /// Method to log the client error
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
		[HttpPost]
        public IActionResult Post([FromBody] LoggerArguments logData)
        {
            // Log the message from the client
            Logger.LogError(logData.Message);
            return Ok();
        }
    }
}
