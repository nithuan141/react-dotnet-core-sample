using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.DataAccess;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.BL
{
    public class ProjectBC : IProjectBC
    {
        private readonly IProjectDAC _projectDAC;

        /// <summary>
        /// COnstructor of Project Bussiness Component
        /// </summary>
        public ProjectBC(IProjectDAC projectDAC)
        {
            _projectDAC = projectDAC;
        }

        /// <summary>
        /// Save the project details
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool SaveProject(ProjectData project)
        {
            var data = new Project()
            {
                Name = project.Name
            };

            return this._projectDAC.SaveProject(data);
        }

        /// <summary>
        /// Returns all the projects 
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetProjects()
        {
            return this._projectDAC.GetProjects().ToList();
        }
    }
}
