using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Api.BL;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : BaseApiController
	{
		private readonly IWorkBC _workBC;
        
        /// <summary>
        /// Work controller constructor
        /// </summary>
        /// <param name="workBC">instance of work bc , injected via constructor</param>
        public WorkController(IWorkBC workBC)
        {
            this._workBC = workBC;
        }

        /// <summary>
        /// Method to add time spend data
        /// </summary>
        /// <param name="workData"></param>
        /// <returns></returns>
        /// api/work/
		[HttpPost]
        public IActionResult Post([FromBody] WorkData workData)
        {
            if (ModelState.IsValid)
            {
                bool result;
                ExecuteGatewayCall(this._workBC.SaveSpendTime, workData, out result);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
            {
                return Ok(false);
            }
        }
    }
}
