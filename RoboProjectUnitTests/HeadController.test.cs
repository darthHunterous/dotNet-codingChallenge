using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RoboProject.Controllers;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class HeadControllerTest
    {
        private Mock<ILogger<HeadController>> _loggerMock;
        private Mock<IDeserializerHelper> _deserializerHelperMock;
        private HeadController _instance;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<HeadController>>();
            _deserializerHelperMock = new Mock<IDeserializerHelper>();
            _instance = new HeadController(_loggerMock.Object, _deserializerHelperMock.Object);
        }

        [Test]
        public void HeadController_Get_ShouldReturnOkResponse_WhenSuccesfullyExecutingLowerCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("lower");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void HeadController_Get_ShouldReturnOkResponse_WhenSuccesfullyExecutingRaiseCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("raise");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void HeadController_Get_ShouldReturnOkResponse_WhenSuccesfullyExecutingLeftCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("left");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void HeadController_Get_ShouldReturnOkResponse_WhenSuccesfullyExecutingRightCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("right");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void HeadController_Get_ShouldThrowAnException_WhenCommandIsInvalid()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.Get("invalid"));
        }
    }
}