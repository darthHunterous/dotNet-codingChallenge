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

        public Robo? deserializeRobo()
        {
            string roboInternalState = File.ReadAllText(jsonFilename);
            Robo? robo = JsonConvert.DeserializeObject<Robo>(roboInternalState);

            if (robo == null)
            {
                throw new Exception("Invalid robot internal state, reload the application");
            }

            setHeadState(robo.Head);
            setArmState(robo.LeftArm);
            setArmState(robo.RightArm);    

            return robo;
        }

        public void serializeRobo(Robo? robo)
        {
            string jsonString = JsonConvert.SerializeObject(robo);
            File.WriteAllText(jsonFilename, jsonString);
        }

        private void setHeadState(Head head)
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

        private void setArmState(Arm arm)
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
