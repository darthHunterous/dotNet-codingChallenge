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
    public class ResetControllerTest
    {
        private Mock<ILogger<ResetController>> _loggerMock;
        private Mock<IDeserializerHelper> _deserializerHelperMock;
        private ResetController _instance;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<ResetController>>();
            _deserializerHelperMock = new Mock<IDeserializerHelper>();
            _instance = new ResetController(_loggerMock.Object, _deserializerHelperMock.Object);
        }

        [Test]
        public void ResetController_Get_ShouldRedirect()
        {
            // Act
            var result = _instance.Get();

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectResult>());
        }
    }
}