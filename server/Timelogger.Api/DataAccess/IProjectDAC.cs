using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.DataAccess
{
    /// <summary>
    /// Interface for Project DAC
    /// </summary>
    public interface IProjectDAC
    {
        /// <summary>
        /// Save the project details
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        bool SaveProject(Project project);

        /// <summary>
        /// Returns all the projects 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetProjects();
    }
}
