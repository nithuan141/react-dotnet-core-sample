using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.Entities
{
    public class InvoiceData: BaseReturnModel
    {
        /// <summary>
        /// The hours spend in a project
        /// </summary>
        public int TimeSpend { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal InvoiceAmt { get; set; }
    }
}
