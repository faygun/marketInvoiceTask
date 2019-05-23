using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanApi.Controllers;
using LoanApi.Dto;

namespace LoanApi.Tests.Controllers
{
    [TestClass]
    public class LoanControllerTest
    {
        [TestMethod]
        public void GetLoanSummary()
        {
            // Arrange
            LoanController controller = new LoanController(new Services.LoanService());

            // Act
            LoanSummaryDto result = controller.GetLoanSummary(50000, 19);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1058, result.WeeklyPayment);
            Assert.AreEqual(55016, result.TotalRepaid);
            Assert.AreEqual(5016, result.TotalInterest);
        }

        [TestMethod]
        public void GetRepaymentSchedule()
        {
            // Arrange
            LoanController controller = new LoanController(new Services.LoanService());

            // Act
            ScheduleDto result = controller.GetRepaymentSchedule(50000, 19);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Installments);
            Assert.AreEqual(52, result.Installments.Count());
            Assert.AreEqual(50000, result.Installments.ElementAt(0).AmountDue);
            Assert.AreEqual(875, result.Installments.ElementAt(0).Principal);
        }
    }
}
