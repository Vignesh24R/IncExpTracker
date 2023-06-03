using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Tests
{
    [TestFixture]
    public class UserBLLTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ILogger<UserBLL>> _loggerMock;
        private IUserBLL _userBLL;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _loggerMock = new Mock<ILogger<UserBLL>>();
            _userBLL = new UserBLL(_userRepositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetUserById_ValidId_ReturnsUser()
        {
            // Arrange
            int id = 1;
            var expectedUser = new User { UserId = id  };
            _userRepositoryMock.Setup(repo => repo.GetUserById(id)).Returns(Task.FromResult(expectedUser));

            // Act
            var result = await _userBLL.GetUserById(id);

            // Assert
            Assert.AreEqual(expectedUser, result);
           
        }

        [Test]
        public void GetUserById_ExceptionThrown_ThrowsArgumentException()
        {
            // Arrange
            int id = 1;
            _userRepositoryMock.Setup(repo => repo.GetUserById(id)).Throws<Exception>();

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _userBLL.GetUserById(id));
        }

     
    }
}
