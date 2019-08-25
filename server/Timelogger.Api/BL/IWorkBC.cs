using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Entities;

namespace Timelogger.Api.BL
{
    public interface IWorkBC
    {
        /// <summary>
        /// Save the spend time on a project
        /// </summary>
        /// <param name="timeSpend"></param>
        /// <returns></returns>
        bool SaveSpendTime(WorkData timeSpend);

        /// <summary>
        /// Get the time spend by a user on a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int GetTimeSpend(int projectId, int userId);

        /// <summary>
        /// Calculate and returns the invoice amount
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        decimal GetInvoiceAmount(int timeSpend, int userId);
    }
}
