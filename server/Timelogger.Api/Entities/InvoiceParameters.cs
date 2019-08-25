using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.Entities
{
    /// <summary>
    /// Entities to useb for passing the invoice calculation parameters
    /// </summary>
    public class InvoiceParameters
    {
        /// <summary>
        /// The hours wored on a project
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Rate per hour
        /// </summary>
        public decimal Rate { get; set; }
    }
}
