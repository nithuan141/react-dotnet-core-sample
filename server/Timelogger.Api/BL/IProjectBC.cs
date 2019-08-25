using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.BL
{
    public interface IProjectBC
    {
        /// <summary>
        /// Save the project details
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        bool SaveProject(ProjectData project);

        /// <summary>
        /// Returns all the projects 
        /// </summary>
        /// <returns></returns>
        IList<Project> GetProjects();
    }
}
