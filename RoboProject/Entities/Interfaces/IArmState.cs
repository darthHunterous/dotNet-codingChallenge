namespace RoboProject.Entities.Interfaces
{
    public interface IArmState
    {
        string Descriptor { get; set; }

        void ContractArm(Arm arm);
        void RelaxArm(Arm arm);
        void RotateWristClockwise(Arm arm);
        void RotateWristCounterClockwise(Arm arm);
    }
}