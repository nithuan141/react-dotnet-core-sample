using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Timelogger.Api.BL;
using Timelogger.Api.DataAccess;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Test
{
    [TestClass]
    public class ProjectBCTest
    {
        private Mock<IProjectDAC> projectDAC;

        private ProjectBC projectBC;

        /// <summary>
        /// initializing the test data  (mock objects etc)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            projectDAC = new Mock<IProjectDAC>();
            projectBC = new ProjectBC(projectDAC.Object);
        }

        /// <summary>
        /// Test of Save Project
        /// </summary>
        [TestMethod]
        public void SaveProject()
        {
            var project = GetProject();

            projectDAC.Setup(x => x.SaveProject(It.IsAny<Project>())).Returns(true);

            bool status = projectBC.SaveProject(new ProjectData()
            {
                Name = "Test project"
            });

            projectDAC.Verify(x => x.SaveProject(It.IsAny<Project>()), Times.Once);
            Assert.IsTrue(status);
        }

        /// <summary>
        /// Test to GetProjects method of project BC
        /// </summary>
        [TestMethod]
        public void GetProjects()
        {
            var project = GetProject();

            projectDAC.Setup(x => x.GetProjects()).Returns(ReturnsProject);

            var result = projectBC.GetProjects();

            projectDAC.Verify(x => x.GetProjects(), Times.Once);
            Assert.IsTrue(result.Count == 1);
        }

        /// <summary>
        /// Test data for single project
        /// </summary>
        /// <returns></returns>
        private Project GetProject()
        {
            return new Timelogger.Entities.Project()
            {
                Id = 1,
                Name = "Test Project"
            };
        }

        /// <summary>
        /// The test data for projects
        /// </summary>
        /// <returns></returns>
        private IList<Project> ReturnsProject()
        {
            IList<Project> data = new List<Project>();
            data.Add(GetProject());

            return data;
        }
    }
}
