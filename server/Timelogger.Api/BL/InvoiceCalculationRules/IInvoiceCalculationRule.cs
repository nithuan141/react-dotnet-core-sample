using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Entities;

namespace Timelogger.Api.BL
{
    public interface IInvoiceCalculationRule
    {
        /// <summary>
        /// calculate the invoice
        /// </summary>
        /// <returns></returns>
        decimal CalculateInvoice(InvoiceParameters parameters);
    }

    /// <summary>
    /// The invoice caluclation rule types
    /// </summary>
    public enum CalculationType
    {
        Normal,
        Complex
    }
}
