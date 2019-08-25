using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.BL
{
    public class InvoiceFactory: IInvoiceFactory
    {
        /// <summary>
        /// Returns the instance of invoice calculation rule based on the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IInvoiceCalculationRule GetCalculationRule(CalculationType type)
        {
            IInvoiceCalculationRule InvoiceRule;
            switch (type)
            {
                case CalculationType.Normal:
                    InvoiceRule = new NormalInvoiceCalculationRule();
                    break;
                default:
                    throw new ArgumentException("Invalid type");
            }

            return InvoiceRule;
        }
    }
}
