namespace RoboProject.Entities.Interfaces
{
    public interface IDeserializerHelper
    {
        public Robo? deserializeRobo();

        public void serializeRobo(Robo? robo);
    }
}
