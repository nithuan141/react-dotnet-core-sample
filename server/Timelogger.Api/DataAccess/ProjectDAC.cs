using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api.DataAccess
{
    /// <summary>
    /// Data access class of projects
    /// </summary>
    public class ProjectDAC: IProjectDAC
    {
        /// <summary>
        /// DB Context instance
        /// </summary>
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProjectDAC(ApiContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Save the project data to database
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool SaveProject(Project project)
        {
            //TODO: This should be an auto incremented primary key.
            project.Id = this._context.Projects.OrderByDescending(x => x.Id).First().Id + 1;
            this._context.Projects.Add(project);
            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Return all the projects
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            return this._context.Projects;
        }
    }
}
