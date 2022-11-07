namespace RoboProject.Entities.Interfaces
{
    public interface IFileHelper
    {
        public string ReadAll(string filename);
        public void WriteAll(string filename, string jsonString);
        public string SerializeRoboObject(Robo robo);
        public Robo? DeserializeRoboObject(string roboInternalState);
    }
}
