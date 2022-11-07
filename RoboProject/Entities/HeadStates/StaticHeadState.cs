using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities.HeadStates
{
    public class StaticHeadState : IHeadState
    {
        public string Descriptor { get; set; }

        public StaticHeadState()
        {
            Descriptor = "Static";
        }

        public void RaiseHead(Head head)
        {
            head.ChangeState(new UpwardsHeadState());
        }

        public void LowerHead(Head head)
        {
            head.ChangeState(new DownwardsHeadState());
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
