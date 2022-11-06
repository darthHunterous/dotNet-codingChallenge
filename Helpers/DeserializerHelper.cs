using RoboProject.Entities.HeadStates;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;
using Newtonsoft.Json;

namespace RoboProject.Helpers
{
    public class DeserializerHelper : IDeserializerHelper
    {
        private const string jsonFilename = "robo.json";

        public Robo? deserializeRobo()
        {
            string roboInternalState = System.IO.File.ReadAllText("robo.json");
            Robo? robo = JsonConvert.DeserializeObject<Robo>(roboInternalState);

            if (robo == null)
            {
                throw new Exception("Invalid robot internal state, reload the application");
            }

            string? headStateDescriptor = robo?.Head.State.Descriptor;

            switch (headStateDescriptor)
            {
                case "Static":
                    if (robo != null)
                    {
                        robo.Head.State = new StaticHeadState();
                    }
                    break;
                case "Upwards":
                    if (robo != null)
                    {
                        robo.Head.State = new UpwardsHeadState();
                    }
                    break;
                case "Downwards":
                    if (robo != null)
                    {
                        robo.Head.State = new DownwardsHeadState();
                    }
                    break;
                default:
                    throw new Exception("Invalid case");
            }

            return robo;
        }

        public void serializeRobo(Robo? robo)
        {
            string jsonString = JsonConvert.SerializeObject(robo);
            System.IO.File.WriteAllText("robo.json", jsonString);
        }
    }
}
