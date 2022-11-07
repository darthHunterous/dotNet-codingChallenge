using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class StaticArmStateTest
    {
        private StaticArmState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new StaticArmState();
        }

        [Test]
        public void HeavilyContractedArmState_ContractArm_ShouldInvokeArmChangeStateToSlightlyContractedArmState()
        {
            // Arrange
            Arm arm = new();
            arm.State = new StaticArmState();

            // Act
            _instance.ContractArm(arm);

            // Assert
            Assert.That(arm.State, Is.InstanceOf<SlightlyContractedArmState>());
        }

        [Test]
        public void HeavilyContractedArmState_RelaxArm_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new StaticArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RelaxArm(arm));
        }

        [Test]
        public void HeavilyContractedArmState_RotateWristClockwise_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new StaticArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristClockwise(arm));
        }

        [Test]
        public void HeavilyContractedArmState_RotateWristCounterClockwise_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new StaticArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristCounterClockwise(arm));
        }
    }
}