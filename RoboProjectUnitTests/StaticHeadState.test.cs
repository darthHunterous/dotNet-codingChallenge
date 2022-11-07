using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;
using RoboProject.Entities.HeadStates;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class StaticHeadStateTest
    {
        private StaticHeadState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new StaticHeadState();
        }

        [Test]
        public void StaticHeadState_RaiseHead_ShouldInvokeHeadChangeStateToUpwardsHeadState()
        {
            // Arrange
            Head head = new();
            head.State = new StaticHeadState();

            // Act
            _instance.RaiseHead(head);

            // Assert
            Assert.That(head.State, Is.InstanceOf<UpwardsHeadState>());
        }

        [Test]
        public void StaticHeadState_LowerHead_ShouldInvokeHeadChangeStateToDownwardsHeadState()
        {
            // Arrange
            Head head = new();
            head.State = new StaticHeadState();

            // Act
            _instance.LowerHead(head);

            // Assert
            Assert.That(head.State, Is.InstanceOf<DownwardsHeadState>());
        }

        [Test]
        public void StaticHeadState_RotateHeadLeft_ShouldDecreaseRotationAngleByFortyFiveDegrees_WhenNotMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new StaticHeadState();
            head.RotationAngle = 0;

            // Act
            _instance.RotateHeadLeft(head);

            // Assert
            Assert.That(head.RotationAngle, Is.EqualTo(-45));
        }

        [Test]
        public void StaticHeadState_RotateHeadLeft_ShouldThrowAnException_WhenMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new StaticHeadState();
            head.RotationAngle = -90;

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateHeadLeft(head));
        }

        [Test]
        public void StaticHeadState_RotateHeadRight_ShouldINcreaseRotationAngleByFortyFiveDegrees_WhenNotMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new StaticHeadState();
            head.RotationAngle = 0;

            // Act
            _instance.RotateHeadRight(head);

            // Assert
            Assert.That(head.RotationAngle, Is.EqualTo(45));
        }

        [Test]
        public void StaticHeadState_RotateHeadRight_ShouldThrowAnException_WhenMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new StaticHeadState();
            head.RotationAngle = 90;

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateHeadRight(head));
        }
    }
}