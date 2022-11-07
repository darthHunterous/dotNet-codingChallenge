namespace RoboProject.Entities
{
    public class Robo
    {
        public long Id { get; set; }
        public Head Head { get; set; }
        public Arm LeftArm { get; set; }
        public Arm RightArm { get; set; }

        public Robo()
        {
            Id = 1;
            Head = new Head();
            LeftArm = new Arm();
            RightArm = new Arm();
        }
    }
}
