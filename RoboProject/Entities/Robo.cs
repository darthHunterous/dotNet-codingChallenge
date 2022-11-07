namespace RoboProject.Entities
{
    public class Robo
    {
        public Head Head { get; set; }
        public Arm LeftArm { get; set; }
        public Arm RightArm { get; set; }

        public Robo()
        {
            Head = new Head();
            LeftArm = new Arm();
            RightArm = new Arm();
        }
    }
}
