using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Api.BL;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : BaseApiController
	{
        /// <summary>
        /// Instance of the project BC, the dependency will be injected via constructor
        /// </summary>
		private readonly IProjectBC _projectBC;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projetBC"></param>
		public ProjectsController(IProjectBC projetBC)
		{
            _projectBC = projetBC;
		}

        /// <summary>
        /// Method to fetch all projects
        /// </summary>
        /// <returns></returns>
        // GET api/projects
        [HttpGet]
        public IActionResult Get()
        {
            IList<Project> result = this._projectBC.GetProjects();
            return Ok(result);
        }

        /// <summary>
        /// Method to fetch a specific project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		// GET api/projects/5
		[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IList<Project> projectList;
            ExecuteGatewayCall(this._projectBC.GetProjects, out projectList);
            if (projectList.Any())
            {
                var project = projectList.FirstOrDefault(p => p.Id == id);


                return Ok(project);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Method to add a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectData project)
        {
            if (ModelState.IsValid)
            {
                bool result;
                this.ExecuteGatewayCall(this._projectBC.SaveProject, project, out result);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
            {
                return Ok(false);
            }
        }
    }
}
