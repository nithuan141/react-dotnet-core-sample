using System.Linq;
using Timelogger.Api.DataAccess;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.BL
{
    /// <summary>
    /// Bussiness component for project and work ( time spend etc)
    /// </summary>
    public class WorkBC : IWorkBC
    {
        /// <summary>
        /// Data access private instance
        /// </summary>
        readonly IWorkDAC _workDAC;

        /// <summary>
        /// Invoice factory instance
        /// </summary>
        readonly IInvoiceFactory _invoiceFactory;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="workDAC"></param>
        /// <param name="invoiceFactory"></param>
        public WorkBC(IWorkDAC workDAC, IInvoiceFactory invoiceFactory)
        {
            this._workDAC = workDAC;
            this._invoiceFactory = invoiceFactory;
        }

        /// <summary>
        /// Saves the time spend data for a project by a user
        /// </summary>
        /// <param name="workData"></param>
        /// <returns></returns>
        public bool SaveSpendTime(WorkData workData)
        {
            Work work = new Work()
            {
                HoursSpend = workData.HoursSpend,
                ProjectId = workData.ProjectId,
                UserId = workData.UserId
            };

            return this._workDAC.SaveSpendTime(work);
        }

        /// <summary>
        /// Get the time spend by a user on a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetTimeSpend(int projectId, int userId)
        {
            // User ID is not using as we are using dummy database
            // Find the time entries of the project and calculating the time spend
            var timeEntries = this._workDAC.GetTimeSpend(projectId).Where(x => x.ProjectId == projectId);
            if (timeEntries.Any())
            {
                return timeEntries.Sum(x => x.HoursSpend);
            }
            return 0;
        }

        /// <summary>
        /// Calculate and returns the invoice amount
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetInvoiceAmount(int timeSpend, int userId)
        {
            // Fetch the invoice instaince from the factory based on the type
            IInvoiceCalculationRule invoice = this._invoiceFactory.GetCalculationRule(CalculationType.Normal);

            InvoiceParameters parameters = new InvoiceParameters()
            {
                Hours = timeSpend,
                Rate = 100 // TODO: dummy value, replace with actual rate.
            };

            // Calculate and return the invoice amout based on the rule
            return invoice.CalculateInvoice(parameters);
        }
    }
}
