using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Tests
{
    [TestFixture]
    public class ReportBLLTests
    {
        private Mock<IReportRepository> _reportRepoMock;
        private Mock<ILogger<ReportBLL>> _loggerMock;
        private IReportBLL _reportBLL;

        [SetUp]
        public void Setup()
        {
            _reportRepoMock = new Mock<IReportRepository>();
            _loggerMock = new Mock<ILogger<ReportBLL>>();
            _reportBLL = new ReportBLL(_reportRepoMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetIncomeByUserRefId_ValidUserRefId_ReturnsIncomeReports()
        {
            // Arrange
            int userRefId = 1;
            var expectedReports = new List<IncomeReportDTO> { /* Mocked income reports */ };
            _reportRepoMock.Setup(repo => repo.GetIncomeByUserRefId(userRefId)).Returns(Task.FromResult(expectedReports));

            // Act
            var result = await _reportBLL.GetIncomeByUserRefId(userRefId);

            // Assert
            Assert.AreEqual(expectedReports, result);
        }

        

        [Test]
        public async Task GetIncomeByDateRange_ValidArguments_ReturnsIncomeReports()
        {
            // Arrange
            int userRefId = 1;
            DateTime fromDate = new DateTime(2023, 1, 1);
            DateTime toDate = new DateTime(2023, 12, 31);
            var expectedReports = new List<IncomeReportDTO> { /* Mocked income reports */ };
            _reportRepoMock.Setup(repo => repo.GetIncomeByDateRange(userRefId, fromDate, toDate))
                           .Returns(Task.FromResult(expectedReports));

            // Act
            var result = await _reportBLL.GetIncomeByDateRange(userRefId, fromDate, toDate);

            // Assert
            Assert.AreEqual(expectedReports, result);
        }

        

        [Test]
        public async Task GetExpensesByUserRefId_ValidUserRefId_ReturnsExpenseReports()
        {
            // Arrange
            int userRefId = 1;
            var expectedReports = new List<ExpenseReportDTO> { /* Mocked expense reports */ };
            _reportRepoMock.Setup(repo => repo.GetExpensesByUserRefId(userRefId))
                           .Returns(Task.FromResult(expectedReports));

            // Act
            var result = await _reportBLL.GetExpensesByUserRefId(userRefId);

            // Assert
            Assert.AreEqual(expectedReports, result);
        }


        [Test]
        public async Task GetExpensesByDateRange_ValidArguments_ReturnsExpenseReports()
        {
            // Arrange
            int userRefId = 1;
            DateTime fromDate = new DateTime(2023, 1, 1);
            DateTime toDate = new DateTime(2023, 12, 31);
            var expectedReports = new List<ExpenseReportDTO> { /* Mocked expense reports */ };
            _reportRepoMock.Setup(repo => repo.GetExpensesByDateRange(userRefId, fromDate, toDate))
                           .Returns(Task.FromResult(expectedReports));

            // Act
            var result = await _reportBLL.GetExpensesByDateRange(userRefId, fromDate, toDate);

            // Assert
            Assert.AreEqual(expectedReports, result);
        }

        

        [Test]
        public async Task GetExpenseReportByCategory_ValidUserRefId_ReturnsExpenseCategoryReports()
        {
            // Arrange
            int userRefId = 1;
            var expectedReports = new List<ExpReportCategoryDTO> { /* Mocked expense category reports */ };
            _reportRepoMock.Setup(repo => repo.GetExpenseReportByCategory(userRefId))
                           .Returns(Task.FromResult(expectedReports));

            // Act
            var result = await _reportBLL.GetExpenseReportByCategory(userRefId);

            // Assert
            Assert.AreEqual(expectedReports, result);
        }


    }
}
