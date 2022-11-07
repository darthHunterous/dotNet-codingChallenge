using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class SlightlyContractedArmStateTest
    {
        private SlightlyContractedArmState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new SlightlyContractedArmState();
        }

        [Test]
        public void SlightlyContractedArmState_ContractArm_ShouldInvokeArmChangeStateToContractedArmState()
        {
            // Arrange
            Arm arm = new();
            arm.State = new SlightlyContractedArmState();

            // Act
            _instance.ContractArm(arm);

            // Assert
            Assert.That(arm.State, Is.InstanceOf<ContractedArmState>());
        }

        [Test]
        public void SlightlyContractedArmState_RelaxArm_ShouldInvokeArmChangeStateToStaticArmState()
        {
            // Arrange
            Arm arm = new();
            arm.State = new SlightlyContractedArmState();

            // Act
            _instance.RelaxArm(arm);

            // Assert
            Assert.That(arm.State, Is.InstanceOf<StaticArmState>());
        }

        [Test]
        public void SlightlyContractedArmState_RotateWristClockwise_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new SlightlyContractedArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristClockwise(arm));
        }

        [Test]
        public void SlightlyContractedArmState_RotateWristCounterClockwise_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new SlightlyContractedArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristCounterClockwise(arm));
        }
    }
}