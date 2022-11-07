using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities.HeadStates
{
    public class UpwardsHeadState : IHeadState
    {
        public string Descriptor { get; set; }

        public UpwardsHeadState()
        {
            Descriptor = "Upwards";
        }

        public void RaiseHead(Head head)
        {
            throw new Exception("Robot's head is already at maximum upwards position");
        }

        public void LowerHead(Head head)
        {
            head.State = new StaticHeadState();
        }

        public void RotateHeadLeft(Head head)
        {
            if (head.RotationAngle > -90)
            {
                head.RotationAngle -= 45;
            }
            else
            {
                throw new Exception("Robot's head is already at maximum leftmost position");
            }
        }

        public void RotateHeadRight(Head head)
        {
            if (head.RotationAngle < 90)
            {
                head.RotationAngle += 45;
            }
            else
            {
                throw new Exception("Robot's head is already at maximum rightmost position");
            }
        }
    }
}
