using System.Collections.Generic;

namespace W6_assignment_template.Interfaces
{
    public interface IContext
    {
        IEnumerable<ICharacter> Characters { get; }
        IRoom StartingRoom { get; }
    }
}