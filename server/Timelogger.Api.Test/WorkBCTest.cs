using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Timelogger.Api.BL;
using Timelogger.Api.DataAccess;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Test
{
    [TestClass]
    public class WorkBCTest
    {
        /// <summary>
        /// mock instance of work DAC
        /// </summary>
        private Mock<IWorkDAC> workDAC;

        /// <summary>
        /// instance of invoice factory
        /// </summary>
        private InvoiceFactory invoiceFactory;

        /// <summary>
        /// Instance of work BC
        /// </summary>
        private WorkBC workBC;

        /// <summary>
        /// initializing the test data  (mock objects etc)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            workDAC = new Mock<IWorkDAC>();
            invoiceFactory = new InvoiceFactory();
            workBC = new WorkBC(workDAC.Object, invoiceFactory);
        }

        /// <summary>
        /// Test for the Savespendtime method of BC
        /// </summary>
        [TestMethod]
        public void SaveSpendTime()
        {
            var timeSpend = GetTimeSpendData();

            workDAC.Setup(x => x.SaveSpendTime(It.IsAny<Work>())).Returns(true);

            bool status = workBC.SaveSpendTime(new WorkData()
            {
                HoursSpend = 10,
                ProjectId = 1,
                UserId = 1
            });

            workDAC.Verify(x => x.SaveSpendTime(It.IsAny<Work>()), Times.Once);
            Assert.IsTrue(status);
        }

        /// <summary>
        /// Test to GetProjects method of project BC
        /// </summary>
        [TestMethod]
        public void GetTimeSpendForProjectWithWork()
        {
            var timeSpend = GetTimeSpendData();

            workDAC.Setup(x => x.GetTimeSpend(1)).Returns(ReturnsTime);

            var result = workBC.GetTimeSpend(1, 1);

            workDAC.Verify(x => x.GetTimeSpend(1), Times.Once);
            Assert.IsTrue(result == 10);
        }

        /// <summary>
        /// Test whether the GetTimeSpend returns 0 without error on poject id with no work data
        /// </summary>
        [TestMethod]
        public void GetTimeSpendForProjectWithNoWork()
        {
            var timeSpend = GetTimeSpendData();

            workDAC.Setup(x => x.GetTimeSpend(1)).Returns(ReturnsTime);

            var result = workBC.GetTimeSpend(2, 1);

            workDAC.Verify(x => x.GetTimeSpend(2), Times.Once);
            Assert.IsTrue(result == 0);
        }

        /// <summary>
        /// Test whether the inovice amount having project with work returns correct invoice amount
        /// </summary>
        [TestMethod]
        public void GetInvoiceAmountForProjectWithWork()
        {
            var result = workBC.GetInvoiceAmount(10, 1);
            Assert.IsTrue(result == 1000);
        }

        /// <summary>
        /// Test whether the inovice amount having project without any work returns 0 as invoice amount
        /// </summary>
        [TestMethod]
        public void GetInvoiceAmountForProjectWithNoWork()
        {
            var result = workBC.GetInvoiceAmount(0, 1);
            Assert.IsTrue(result == 0);
        }

        /// <summary>
        /// TimeSpend data 
        /// </summary>
        /// <returns></returns>
        private Work GetTimeSpendData()
        {
            return new Work()
            {
                HoursSpend = 10,
                ProjectId = 1,
                UserId = 1
            };
        }

        /// <summary>
        /// Return data for spend time
        /// </summary>
        /// <returns></returns>
        private IList<Work> ReturnsTime()
        {
            IList<Work> data = new List<Work>();
            data.Add(GetTimeSpendData());

            return data;
        }

    }
}
