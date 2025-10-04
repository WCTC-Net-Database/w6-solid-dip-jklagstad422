namespace W6_assignment_template.Interfaces
{
    public interface IRoom
    {
        string Name { get; }
        string Description { get; }
        void Enter();
    }
}