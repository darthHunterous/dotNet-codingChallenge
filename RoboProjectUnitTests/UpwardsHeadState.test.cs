using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;
using RoboProject.Entities.HeadStates;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class UpwardsHeadStateTest
    {
        private UpwardsHeadState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new UpwardsHeadState();
        }

        [Test]
        public void UpwardsHeadState_RaiseHead_ShouldThrowException()
        {
            // Arrange
            Head head = new();
            head.State = new UpwardsHeadState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RaiseHead(head));
        }

        [Test]
        public void UpwardsHeadState_LowerHead_ShouldInvokeHeadChangeStateToStaticHeadState()
        {
            // Arrange
            Head head = new();
            head.State = new UpwardsHeadState();

            // Act
            _instance.LowerHead(head);

            // Assert
            Assert.That(head.State, Is.InstanceOf<StaticHeadState>());
        }

        [Test]
        public void UpwardsHeadState_RotateHeadLeft_ShouldDecreaseRotationAngleByFortyFiveDegrees_WhenNotMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new UpwardsHeadState();
            head.RotationAngle = 0;

            // Act
            _instance.RotateHeadLeft(head);

            // Assert
            Assert.That(head.RotationAngle, Is.EqualTo(-45));
        }

        [Test]
        public void UpwardsHeadState_RotateHeadLeft_ShouldThrowAnException_WhenMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new UpwardsHeadState();
            head.RotationAngle = -90;

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateHeadLeft(head));
        }

        [Test]
        public void UpwardsHeadState_RotateHeadRight_ShouldIncreaseRotationAngleByFortyFiveDegrees_WhenNotMaxed()
        {
            // Arrange
            Head head = new();
            head.State = new UpwardsHeadState();
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
            head.State = new UpwardsHeadState();
            head.RotationAngle = 90;

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateHeadRight(head));
        }
    }
}