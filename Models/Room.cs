using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Room : IRoom
    {
        public string Name { get; }
        public string Description { get; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Enter()
        {
          
        }
    }
}