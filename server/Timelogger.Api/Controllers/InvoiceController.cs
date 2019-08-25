using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Api.BL;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/invoice")]
    public class InvoiceController : BaseApiController
	{
        /// <summary>
        /// Instance of the workBC ( Bussiness component)
        /// </summary>
		private readonly IWorkBC _workBC;

        /// <summary>
        /// Constructor of invoice controller
        /// </summary>
        /// <param name="workBC">Injecting the workBC instance using parameter</param>
        public InvoiceController(IWorkBC workBC)
        {
            this._workBC = workBC;
        }

        /// <summary>
        /// Method to get the invoice amount
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		// GET api/Invoice/5
		[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Get the hours spend on the project
            int hoursSpend;
            this.ExecuteGatewayCall(this._workBC.GetTimeSpend, id, 1, out hoursSpend);

            // Get the invoice amount based on the hours spend
            decimal invoiceAmt;
            this.ExecuteGatewayCall(this._workBC.GetInvoiceAmount, hoursSpend, 1, out invoiceAmt);

            InvoiceData invoiceData = new InvoiceData()
            {
                TimeSpend = hoursSpend,
                InvoiceAmt = invoiceAmt
            };

			return Ok(invoiceData);
        }
    }
}
