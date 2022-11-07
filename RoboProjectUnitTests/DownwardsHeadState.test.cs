using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;
using RoboProject.Entities.HeadStates;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class DownwardsHeadStateTest
    {
        private DownwardsHeadState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new DownwardsHeadState();
        }

        [Test]
        public void DownwardsHeadState_RaiseHead_ShouldInvokeHeadChangeStateToStaticHeadState()
        {
            // Arrange
            Head head = new();
            head.State = new DownwardsHeadState();

            // Act
            _instance.RaiseHead(head);

            // Assert
            Assert.That(head.State, Is.InstanceOf<StaticHeadState>());
        }

        [Test]
        public void DownwardsHeadState_LowerHead_ShouldThrowException()
        {
            // Arrange
            Head head = new();
            head.State = new DownwardsHeadState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.LowerHead(head));
        }

        [Test]
        public void DownwardsHeadState_RotateHeadLeft_ShouldThrowException()
        {
            // Arrange
            Head head = new();
            head.State = new DownwardsHeadState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateHeadLeft(head));
        }

        [Test]
        public void DownwardsHeadState_RotateHeadRight_ShouldThrowException()
        {
            // Arrange
            Head head = new();
            head.State = new DownwardsHeadState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateHeadRight(head));
        }
    }
}