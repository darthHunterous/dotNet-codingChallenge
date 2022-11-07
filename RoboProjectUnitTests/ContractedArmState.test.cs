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
    public class ContractedArmStateTest
    {
        private ContractedArmState _instance;

        [SetUp]
        public void Setup()
        {
            _instance = new ContractedArmState();
        }

        [Test]
        public void ContractedArmState_ContractArm_ShouldInvokeArmChangeStateToHeavilyContractedArmState()
        {
            // Arrange
            Arm arm = new();
            arm.State = new ContractedArmState();

            // Act
            _instance.ContractArm(arm);

            // Assert
            Assert.That(arm.State, Is.InstanceOf<HeavilyContractedArmState>());
        }

        [Test]
        public void ContractedArmState_RelaxArm_ShouldInvokeArmChangeStateToStaticArmState()
        {
            // Arrange
            Arm arm = new();
            arm.State = new ContractedArmState();

            // Act
            _instance.RelaxArm(arm);

            // Assert
            Assert.That(arm.State, Is.InstanceOf<StaticArmState>());
        }

        [Test]
        public void ContractedArmState_RotateWristClockwise_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new ContractedArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristClockwise(arm));
        }

        [Test]
        public void ContractedArmState_RotateWristCounterClockwise_ShouldThrowAnException()
        {
            // Arrange
            Arm arm = new();
            arm.State = new ContractedArmState();

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.RotateWristCounterClockwise(arm));
        }
    }
}