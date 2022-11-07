using Newtonsoft.Json;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string ReadAll(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void WriteAll(string filename, string jsonString)
        {
            File.WriteAllText(filename, jsonString);
        }

        public string SerializeRoboObject(Robo robo)
        {
            return JsonConvert.SerializeObject(robo);
        }

        public Robo? DeserializeRoboObject(string roboInternalState)
        {
            return JsonConvert.DeserializeObject<Robo>(roboInternalState);
        }
    }
}
