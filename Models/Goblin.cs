using System;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Goblin : CharacterBase
    {
        private readonly Random _random = new Random();

        public Goblin(int hitPoints, int level, IRoom startingRoom)
            : base("Goblin Grunt", hitPoints, "Goblin", level, startingRoom)
        {
        }

        public override void PerformSpecialAction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} screams an unsettling war cry!");
            Console.ResetColor();
        }

        // Encapsulate AI logic here (DIP)
        public override void TakeTurn(ICharacter target)
        {
            if (HitPoints <= 0) return;

            if (HitPoints < 20)
            {
                int heal = _random.Next(5, 10);
                base.Heal(heal);
            }
            else
            {
                int damage = _random.Next(5, 15);
                base.Attack(target, damage);
            }
        }
    }
}