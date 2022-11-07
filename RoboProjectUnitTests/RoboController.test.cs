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
    public class RoboControllerTest
    {
        private Mock<ILogger<RoboController>> _loggerMock;
        private Mock<IDeserializerHelper> _deserializerHelperMock;
        private RoboController _instance;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<RoboController>>();
            _deserializerHelperMock = new Mock<IDeserializerHelper>();
            _instance = new RoboController(_loggerMock.Object, _deserializerHelperMock.Object);
        }

        [Test]
        public void RoboController_Get_ShouldReturnOkResponse_WhenSuccesfullyReturningDeserializedRobo()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

    }
}