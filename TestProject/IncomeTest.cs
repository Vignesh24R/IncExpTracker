using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Tests
{
    [TestFixture]
    public class IncomeBLLTests
    {
        private Mock<IIncomeRepository> _incomeRepoMock;
        private Mock<ILogger<IncomeBLL>> _loggerMock;
        private IIncomeBLL _incomeBLL;

        [SetUp]
        public void Setup()
        {
            _incomeRepoMock = new Mock<IIncomeRepository>();
            _loggerMock = new Mock<ILogger<IncomeBLL>>();
            _incomeBLL = new IncomeBLL(_incomeRepoMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task CreateIncome_ValidIncomeDTO_CallsCreateIncomeOnRepository()
        {
            // Arrange
            var incomeDTO = new IncomeDTO { /* Mocked income DTO */ };

            // Act
            await _incomeBLL.CreateIncome(incomeDTO);

            // Assert
            _incomeRepoMock.Verify(repo => repo.CreateIncome(incomeDTO), Times.Once);
        }

        [Test]
        public void CreateIncome_ExceptionThrown_LogsErrorAndThrowsException()
        {
            // Arrange
            var incomeDTO = new IncomeDTO { /* Mocked income DTO */ };
            _incomeRepoMock.Setup(repo => repo.CreateIncome(incomeDTO)).Throws<Exception>();

            // Act + Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _incomeBLL.CreateIncome(incomeDTO));
        }

        [Test]
        public async Task GetIncomeByUserRefId_ValidUserRefId_ReturnsIncomeDTOList()
        {
            // Arrange
            int userRefId = 1;
            var expectedIncomeList = new List<IncomeDTO> { /* Mocked income DTO list */ };
            _incomeRepoMock.Setup(repo => repo.GetIncomeByUserRefId(userRefId)).Returns(Task.FromResult(expectedIncomeList));

            // Act
            var result = await _incomeBLL.GetIncomeByUserRefId(userRefId);

            // Assert
            Assert.AreEqual(expectedIncomeList, result);
        }

        [Test]
        public void GetIncomeByUserRefId_ExceptionThrown_LogsErrorAndThrowsException()
        {
            // Arrange
            int userRefId = 1;
            _incomeRepoMock.Setup(repo => repo.GetIncomeByUserRefId(userRefId)).Throws<Exception>();

        }

        [Test]
        public async Task UpdateIncome_ValidArguments_CallsUpdateIncomeOnRepository()
        {
            // Arrange
            int incomeId = 1;
            int userRefId = 1;
            var incomeDTO = new IncomeDTO { /* Mocked income DTO */ };

            // Act
            await _incomeBLL.UpdateIncome(incomeId, userRefId, incomeDTO);

            // Assert
            _incomeRepoMock.Verify(repo => repo.UpdateIncome(incomeId, userRefId, incomeDTO), Times.Once);
        }

        [Test]
        public void UpdateIncome_ExceptionThrown_LogsErrorAndThrowsException()
        {
            // Arrange
            int incomeId = 1;
            int userRefId = 1;
            var incomeDTO = new IncomeDTO { /* Mocked income DTO */ };
            _incomeRepoMock.Setup(repo => repo.UpdateIncome(incomeId, userRefId, incomeDTO)).Throws<Exception>();

            // Act + Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _incomeBLL.UpdateIncome(incomeId, userRefId, incomeDTO));

        }


        [Test]
        public void DeleteIncome_ExceptionThrown_LogsErrorAndThrowsException()
        {
            // Arrange
            int incomeId = 1;
            int userRefId = 1;
            _incomeRepoMock.Setup(repo => repo.DeleteIncome(incomeId, userRefId)).Throws<Exception>();

            
            
        }
    }
}
