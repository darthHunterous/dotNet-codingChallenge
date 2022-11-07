using Moq;
using NUnit.Framework;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;
using RoboProject.Entities.HeadStates;
using RoboProject.Entities.Interfaces;
using RoboProject.Helpers;

namespace RoboProjectUnitTests
{
    [TestFixture]
    public class DeserializerHelperTest
    {
        private Mock<IFileHelper> _fileHelperMock;
        private DeserializerHelper _instance;

        [SetUp]
        public void Setup()
        {
            _fileHelperMock = new Mock<IFileHelper>();
            _instance = new DeserializerHelper(_fileHelperMock.Object);
        }

        [Test]
        public void DeserializerHelper_DeserializeRobo_ShouldReturnRobo_WhenOriginalRoboNotNull()
        {
            // Arrange
            Robo robo = new();
            _fileHelperMock.Setup(_ => _.ReadAll(It.IsAny<string>()))
                .Returns("{\"Id\":1,\"Head\":{\"RotationAngle\":-90,\"State\":{\"Descriptor\":\"Static\"}}" +
                ",\"LeftArm\":{\"RotationAngle\":0,\"State\":{\"Descriptor\":\"Static\"}}," +
                "\"RightArm\":{\"RotationAngle\":0,\"State\":{\"Descriptor\":\"Static\"}}}");
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result, Is.EqualTo(robo));
        }

        [Test]
        public void DeserializerHelper_DeserializeRobo_ShouldReturnNewDefaultRobo_WhenOriginalRoboNull()
        {
            // Arrange
            Robo robo = new();
            _fileHelperMock.Setup(_ => _.ReadAll(It.IsAny<string>()))
                .Returns("null");
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns((Robo)null);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result.Head.State.Descriptor, Is.EqualTo(robo.Head.State.Descriptor));
        }

        [Test]
        public void DeserializerHelper_SerializeRobo_ShouldExecuteWithoutIssues()
        {
            // Arrange
            Robo robo = new();
            _fileHelperMock.Setup(_ => _.SerializeRoboObject(It.IsAny<Robo>())).Returns("jsonFileHere");

            // Act & Assert
            Assert.DoesNotThrow(() => _instance.SerializeRobo(robo));
        }

        [Test]
        public void DeserializerHelper_SetHeadState_ShouldChangeHeadStateToStatic_WhenGivenStaticHeadStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.Head.State = new StaticHeadState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.Head.State, Is.InstanceOf<StaticHeadState>());
        }

        [Test]
        public void DeserializerHelper_SetHeadState_ShouldChangeHeadStateToUpwards_WhenGivenUpwardsHeadStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.Head.State = new UpwardsHeadState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.Head.State, Is.InstanceOf<UpwardsHeadState>());
        }

        [Test]
        public void DeserializerHelper_SetHeadState_ShouldChangeHeadStateToDownwards_WhenGivenDownwardsHeadStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.Head.State = new DownwardsHeadState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.Head.State, Is.InstanceOf<DownwardsHeadState>());
        }

        [Test]
        public void DeserializerHelper_SetHeadState_ShouldThrowAnException_WhenGivenInvalidHeadStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.Head.State.Descriptor = "Invalid";
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.DeserializeRobo());
        }

        [Test]
        public void DeserializerHelper_SetArmState_ShouldChangeArmStateToStatic_WhenGivenStaticArmStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new StaticArmState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.LeftArm.State, Is.InstanceOf<StaticArmState>());
        }

        [Test]
        public void DeserializerHelper_SetArmState_ShouldChangeArmStateToSlightlyContracted_WhenGivenSlightlyContractedArmStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new SlightlyContractedArmState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.LeftArm.State, Is.InstanceOf<SlightlyContractedArmState>());
        }

        [Test]
        public void DeserializerHelper_SetArmState_ShouldChangeArmStateToContracted_WhenGivenContractedArmStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new ContractedArmState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.LeftArm.State, Is.InstanceOf<ContractedArmState>());
        }

        [Test]
        public void DeserializerHelper_SetArmState_ShouldChangeArmStateToHeavilyContracted_WhenGivenHeavilyContractedArmStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State = new HeavilyContractedArmState();
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act
            var result = _instance.DeserializeRobo();

            // Assert
            Assert.That(result?.LeftArm.State, Is.InstanceOf<HeavilyContractedArmState>());
        }

        [Test]
        public void DeserializerHelper_SetArmState_ShouldThrowAnException_WhenGivenInvalidArmStateDescriptor()
        {
            // Arrange
            Robo robo = new();
            robo.LeftArm.State.Descriptor = "Invalid";
            _fileHelperMock.Setup(_ => _.DeserializeRoboObject(It.IsAny<string>())).Returns(robo);

            // Act & Assert
            Assert.Throws<Exception>(() => _instance.DeserializeRobo());
        }
    }
}