namespace RoboProject.Entities.Interfaces
{
    public interface IDeserializerHelper
    {
        public Robo? DeserializeRobo();

        public void SerializeRobo(Robo? robo);
    }
}
