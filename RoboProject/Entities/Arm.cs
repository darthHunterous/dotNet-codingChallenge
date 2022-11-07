using RoboProject.Entities.ArmStates;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities
{
    public class Arm
    {
        public int RotationAngle { get; set; }
        public IArmState State { get; set; }

        public Arm()
        {
            RotationAngle = 0;
            State = new StaticArmState();
        }

        public void ContractArm()
        {
            State.ContractArm(this);
        }

        public void RelaxArm()
        {
            State.RelaxArm(this);
        }

        public void RotateWristClockwise()
        {
            State.RotateWristClockwise(this);
        }

        public void RotateWristCounterClockwise()
        {
            State.RotateWristCounterClockwise(this);
        }

        public void ChangeState(IArmState state)
        {
            State = state;
        }
    }
}
