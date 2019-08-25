using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Entities;

namespace Timelogger.Api.BL
{
    public class NormalInvoiceCalculationRule : IInvoiceCalculationRule
    {
        /// <summary>
        /// Calculating the invoice and returning the bill amount - normal caculation
        /// </summary>
        /// <returns></returns>
        public decimal CalculateInvoice(InvoiceParameters parameters)
        {
            return (parameters.Hours * parameters.Rate);
        }
    }
}
