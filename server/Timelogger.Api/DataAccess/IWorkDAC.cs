using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Api.DataAccess
{
    /// <summary>
    /// Inteface for time spend Data access component
    /// </summary>
    public interface IWorkDAC
    {
        /// <summary>
        /// Save the time spend on a project
        /// </summary>
        /// <param name="timeSpend"></param>
        /// <returns></returns>
        bool SaveSpendTime(Work timeSpend);

        /// <summary>
        /// Returns all the time spend data of given project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        IEnumerable<Work> GetTimeSpend(int projectId);
    }
}
