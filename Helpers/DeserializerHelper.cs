using RoboProject.Entities.HeadStates;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;
using Newtonsoft.Json;
using RoboProject.Entities.ArmStates;

namespace RoboProject.Helpers
{
    public class DeserializerHelper : IDeserializerHelper
    {
        private const string jsonFilename = "robo.json";

        private IFileHelper _fileHelper;

        public DeserializerHelper(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper; 
        }

        public Robo? DeserializeRobo()
        {
            string roboInternalState = _fileHelper.ReadAll(jsonFilename);
            Robo? robo = _fileHelper.DeserializeRoboObject(roboInternalState);

            if (robo == null)
            {
                throw new Exception("Invalid robot internal state, reload the application");
            }

            SetHeadState(robo.Head);
            SetArmState(robo.LeftArm);
            SetArmState(robo.RightArm);    

            return robo;
        }

        public void SerializeRobo(Robo? robo)
        {
            string jsonString = _fileHelper.SerializeRoboObject(robo);
            _fileHelper.WriteAll(jsonFilename, jsonString);
        }

        private void SetHeadState(Head head)
        {
            string? headStateDescriptor = head.State.Descriptor;

            switch (headStateDescriptor)
            {
                case "Static":
                    head.State = new StaticHeadState();
                    break;
                case "Upwards":
                    head.State = new UpwardsHeadState();
                    break;
                case "Downwards":
                    head.State = new DownwardsHeadState();
                    break;
                default:
                    throw new Exception("Invalid case");
            }
        }

        private void SetArmState(Arm arm)
        {
            string armStateDescriptor = arm.State.Descriptor;

            switch (armStateDescriptor)
            {
                case "Static":
                    arm.State = new StaticArmState();
                    break;
                case "Slightly Contracted":
                    arm.State = new SlightlyContractedArmState();
                    break;
                case "Contracted":
                    arm.State = new ContractedArmState();
                    break;
                case "Heavily Contracted":
                    arm.State = new HeavilyContractedArmState();
                    break;
                default:
                    throw new Exception("Invalid case");
            }
        }
    }
}
