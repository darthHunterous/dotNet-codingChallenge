using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RoboProject.Controllers;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;
using RoboProject.Entities.Interfaces;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class ArmControllerTest
    {
        private Mock<ILogger<HeadController>> _loggerMock;
        private Mock<IDeserializerHelper> _deserializerHelperMock;
        private ArmController _instance;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<HeadController>>();
            _deserializerHelperMock = new Mock<IDeserializerHelper>();
            _instance = new ArmController(_loggerMock.Object, _deserializerHelperMock.Object);
        }

        [Test]
        public void ArmController_Get_ShouldReturnOkResponse_WhenSelectingLeftArmAndValidCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("left", "contract");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void ArmController_Get_ShouldReturnOkResponse_WhenSelectingRightArmAndValidCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("right", "contract");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void ArmController_Get_ShouldThrowAnException_WhenSelectedArmIsInvalidAndValidCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.Get("leg", "contract"));
        }

        [Test]
        public void ArmController_Get_ShouldReturnOkResponse_WhenSelectingContractCommandAndArmIsValid()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("left", "contract");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void ArmController_Get_ShouldReturnOkResponse_WhenSelectingRelaxCommandAndArmIsValid()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new HeavilyContractedArmState();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("left", "relax");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void ArmController_Get_ShouldReturnOkResponse_WhenSelectingClockwiseCommandAndArmIsValid()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new HeavilyContractedArmState();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("left", "clockwise");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void ArmController_Get_ShouldReturnOkResponse_WhenSelectingCounterClockwiseCommandAndArmIsValid()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new HeavilyContractedArmState();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act
            var result = _instance.Get("left", "counterclockwise");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void ArmController_Get_ShouldThrowAnException_WhenSelectedArmIsValidAndInvalidCommand()
        {
            // Arrange
            Robo robo = new();
            _deserializerHelperMock.Setup(_ => _.DeserializeRobo()).Returns(robo);

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.Get("left", "donothing"));
        }
    }
}