using RoboProject.Entities.Interfaces;

namespace RoboProject.Entities.ArmStates
{
    public class HeavilyContractedArmState : IArmState
    {
        public string Descriptor { get; set; }

        public HeavilyContractedArmState()
        {
            Descriptor = "Heavily Contracted";
        }

        public void ContractArm(Arm arm)
        {
            throw new Exception("Robot's arm is already at maximum contracted position");
        }

        public void RelaxArm(Arm arm)
        {
            arm.ChangeState(new ContractedArmState());
        }

        public void RotateWristClockwise(Arm arm)
        {
            if (arm.RotationAngle < 180)
            {
                arm.RotationAngle += 45;
            }
            else
            {
                throw new Exception("Robot's arm is already at clockwise-most position");
            }
        }

        public void RotateWristCounterClockwise(Arm arm)
        {
            if (arm.RotationAngle > -90)
            {
                arm.RotationAngle -= 45;
            }
            else
            {
                throw new Exception("Robot's arm is already at counterclockwise-most position");
            }
        }
    }
}
