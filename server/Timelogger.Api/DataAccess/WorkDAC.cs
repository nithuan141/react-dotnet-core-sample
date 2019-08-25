using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Api.DataAccess
{
    public class WorkDAC : IWorkDAC
    {
        /// <summary>
        /// DB Context instance
        /// </summary>
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public WorkDAC(ApiContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Save the time spend on a project
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        public bool SaveSpendTime(Work work)
        {
            // TODO: This should be a PK. This is a dummy code to generate id
            work.Id = this._context.Work.OrderByDescending(x => x.Id).First().Id + 1;
            this._context.Work.Add(work);
            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Returns all the time spend data of given project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IEnumerable<Work> GetTimeSpend(int projectId)
        {
            return this._context.Work.Where(x => x.ProjectId == projectId);
        }
    }
}
