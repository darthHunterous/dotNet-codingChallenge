using RoboProject.Entities.HeadStates;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities
{
    public class Head
    {
        public int RotationAngle { get; set; }
        public IHeadState State { get; set; }

        public Head()
        {
            RotationAngle = 0;
            State = new StaticHeadState();
        }

        public void RaiseHead()
        {
            State.RaiseHead(this);
        }

        public void LowerHead()
        {
            State.LowerHead(this);
        }

        public void RotateHeadLeft()
        {
            State.RotateHeadLeft(this);
        }

        public void RotateHeadRight()
        {
            State.RotateHeadRight(this);
        }

        public void ChangeState(IHeadState state)
        {
            State = state;
        }
    }
}
