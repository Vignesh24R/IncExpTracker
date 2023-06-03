using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Business_Logic_Layer.Services.Tests
{
    [TestFixture]
    public class ExpenseBLLTests
    {
        private Mock<IExpenseRepository> _expenseRepoMock;
        private Mock<ILogger<ExpenseBLL>> _loggerMock;
        private IExpenseBLL _expenseBLL;

        [SetUp]
        public void Setup()
        {
            _expenseRepoMock = new Mock<IExpenseRepository>();
            _loggerMock = new Mock<ILogger<ExpenseBLL>>();
            _expenseBLL = new ExpenseBLL(_expenseRepoMock.Object, _loggerMock.Object);
        }

        [Test]
        public void CreateExpense_ValidExpenseDto_ReturnsExpenseDto()
        {
            // Arrange
            var expenseDto = new ExpenseDTO();
            _expenseRepoMock.Setup(repo => repo.CreateExpense(expenseDto)).Returns(expenseDto);

            // Act
            var result = _expenseBLL.CreateExpense(expenseDto);

            // Assert
            Assert.AreEqual(expenseDto, result);
           
        }

        [Test]
        public void GetExpenseByUserRefId_ValidUserRefId_ReturnsExpenseDto()
        {
            // Arrange
            var userRefId = 1;
            var expenseDto = new ExpenseDTO();
            _expenseRepoMock.Setup(repo => repo.GetExpenseByUserRefId(userRefId)).Returns(expenseDto);

            // Act
            var result = _expenseBLL.GetExpenseByUserRefId(userRefId);

            // Assert
            Assert.AreEqual(expenseDto, result);
           
        }

        [Test]
        public void UpdateExpense_ValidExpenseData_ReturnsTrue()
        {
            // Arrange
            var expenseId = 1;
            var userRefId = 1;
            var expenseDto = new ExpenseDTO();
            _expenseRepoMock.Setup(repo => repo.UpdateExpense(expenseId, userRefId, expenseDto)).Returns(true);

            // Act
            var result = _expenseBLL.UpdateExpense(expenseId, userRefId, expenseDto);

            // Assert
            Assert.IsTrue(result);
            
        }

        [Test]
        public void DeleteExpense_ValidUserAndExpenseId_ReturnsTrue()
        {
            // Arrange
            var userRefId = 1;
            var expenseId = 1;
            _expenseRepoMock.Setup(repo => repo.DeleteExpense(userRefId, expenseId)).Returns(true);

            // Act
            var result = _expenseBLL.DeleteExpense(userRefId, expenseId);

            // Assert
            Assert.IsTrue(result);
            
        }
    }
}
