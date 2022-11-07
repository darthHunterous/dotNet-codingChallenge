using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class HeavilyContractedArmStateTest
    {
        private HeavilyContractedArmState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new HeavilyContractedArmState();
        }

        [Test]
        public void HeavilyContractedArmState_ContractArm_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new HeavilyContractedArmState();            

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.ContractArm(arm));            
        }

        [Test]
        public void HeavilyContractedArmState_RelaxArm_ShouldInvokeArmChangeStateToContractedArmState()
        {
            // Arrange
            Arm arm = new();
            arm.State = new HeavilyContractedArmState();

            // Act
            _instance.RelaxArm(arm);

            // Assert
            Assert.That(arm.State, Is.InstanceOf<ContractedArmState>());
        }

        [Test]
        public void HeavilyContractedArmState_RotateWristClockwise_ShouldIncreaseRotationAngleByFortyFiveDegrees_WhenNotMaxed()
        {
            // Arrange
            Arm arm = new();
            arm.State = new HeavilyContractedArmState();
            arm.RotationAngle = 45;

            // Act
            _instance.RotateWristClockwise(arm);

            // Assert
            Assert.That(arm.RotationAngle, Is.EqualTo(90));
        }

        [Test]
        public void HeavilyContractedArmState_RotateWristClockwise_ShouldThrowAnException_WhenRotationAngleIsAtMaximum()
        {
            // Arrange
            Arm arm = new();
            arm.State = new HeavilyContractedArmState();
            arm.RotationAngle = 180;

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristClockwise(arm));
        }

        [Test]
        public void HeavilyContractedArmState_RotateWristCounterClockwise_ShouldDecreaseRotationAngleByFortyFiveDegrees_WhenNotMaxed()
        {
            // Arrange
            Arm arm = new();
            arm.State = new HeavilyContractedArmState();
            arm.RotationAngle = 45;

            // Act
            _instance.RotateWristCounterClockwise(arm);

            // Assert
            Assert.That(arm.RotationAngle, Is.EqualTo(0));
        }

        [Test]
        public void HeavilyContractedArmState_RotateWristCounterClockwise_ShouldThrowAnException_WhenRotationAngleIsAtMaximum()
        {
            // Arrange
            Arm arm = new();
            arm.State = new HeavilyContractedArmState();
            arm.RotationAngle = -90;

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristCounterClockwise(arm));
        }
    }
}