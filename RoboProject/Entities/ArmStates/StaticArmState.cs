using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities.ArmStates
{
    public class StaticArmState : IArmState
    {
        public string Descriptor { get; set; }

        public StaticArmState()
        {
            Descriptor = "Static";
        }

        public void ContractArm(Arm arm)
        {
            arm.ChangeState(new SlightlyContractedArmState());
        }

        public void RelaxArm(Arm arm)
        {
            throw new Exception("Robot's arm is already at maximum relaxed position");
        }

        public void RotateWristClockwise(Arm arm)
        {
            throw new Exception("Robot's arm can only be rotated at maximum contracted position");
        }

        public void RotateWristCounterClockwise(Arm arm)
        {
            throw new Exception("Robot's arm can only be rotated at maximum contracted position");
        }
    }
}
