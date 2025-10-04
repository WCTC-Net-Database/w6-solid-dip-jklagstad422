using System.Collections.Generic;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models; 

namespace W6_assignment_template.Data 
{

    public class GameContext : IContext
    {
        private readonly List<ICharacter> _characters = new List<ICharacter>();

        public IRoom StartingRoom { get; }

        public GameContext()
        {
       
            StartingRoom = new Room("The Old Library", "Dust motes dance in the faded light. The air is still and cold.");

            var player = new Player("Aragorn", 100, 5, StartingRoom);
            var goblin = new Goblin(50, 1, StartingRoom);
            var ghost = new Ghost(75, 3, StartingRoom);

            _characters.Add(player);
            _characters.Add(goblin);
            _characters.Add(ghost);
        }

        public IEnumerable<ICharacter> Characters => _characters;
    }
}