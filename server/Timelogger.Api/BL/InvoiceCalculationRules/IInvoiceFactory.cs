using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.BL
{
    /// <summary>
    /// Interface for the invoice factory
    /// </summary>
    public interface IInvoiceFactory
    {
        /// <summary>
        /// Returns the instance of invoice calculation rule based on the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IInvoiceCalculationRule GetCalculationRule(CalculationType type);
    }
}
