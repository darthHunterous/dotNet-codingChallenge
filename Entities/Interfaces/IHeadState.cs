namespace RoboProject.Entities.Interfaces
{
    public interface IHeadState
    {
        string Descriptor { get; set; }

        void RaiseHead(Head head);
        void LowerHead(Head head);
        void RotateHeadLeft(Head head);
        void RotateHeadRight(Head head);
    }
}