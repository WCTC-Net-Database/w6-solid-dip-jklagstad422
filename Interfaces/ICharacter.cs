using System.Collections.Generic;

namespace W6_assignment_template.Interfaces
{
    public interface ICharacter
    {
        string Name { get; set; }
        int HitPoints { get; set; }
        string Class { get; }
        int Level { get; }

        void MoveToRoom(IRoom room);
        void PerformSpecialAction();
        void Attack(ICharacter target, int damage);
        void Heal(int healAmount);
        void TakeTurn(ICharacter target);
    }
}