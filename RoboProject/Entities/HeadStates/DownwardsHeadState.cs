using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities.HeadStates
{
    public class DownwardsHeadState : IHeadState
    {
        public string Descriptor { get; set; }

        public DownwardsHeadState()
        {
            Descriptor = "Downwards";
        }

        public void RaiseHead(Head head)
        {
            head.State = new StaticHeadState();
        }

        public void LowerHead(Head head)
        {
            throw new Exception("Robot's head is already at maximum downwards position");
        }

        public void RotateHeadLeft(Head head)
        {
            throw new Exception("Downwards - Robot's head can't be turned in downwards position");
        }

        public void RotateHeadRight(Head head)
        {
            throw new Exception("Robot's head can't be turned in downwards position");
        }
    }
}
