using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities.ArmStates
{
    public class ContractedArmState : IArmState
    {
        public string Descriptor { get; set; }

        public ContractedArmState()
        {
            Descriptor = "Contracted";
        }

        public void ContractArm(Arm arm)
        {
            arm.ChangeState(new HeavilyContractedArmState());
        }

        public void RelaxArm(Arm arm)
        {
            arm.ChangeState(new StaticArmState());
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
