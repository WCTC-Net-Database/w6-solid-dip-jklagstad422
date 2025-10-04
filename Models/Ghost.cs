using System;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Ghost : CharacterBase
    {
        public bool IsHostile { get; private set; } = true;
        private readonly Random _random = new Random();

        public Ghost(int hitPoints, int level, IRoom startingRoom)
            : base("Wandering Ghost", hitPoints, "Ethereal", level, startingRoom)
        {
        }

  
        public Ghost() : base("Wandering Ghost", 0, "Ethereal", 1, null) { }

        public void Fly()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} phases through the wall!");
            Console.ResetColor();
        }

        public override void PerformSpecialAction()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} unleashes a chilling, debilitating moan!");
            Console.ResetColor();
        }

        public override void TakeTurn(ICharacter target)
        {
            if (HitPoints <= 0) return;

            if (IsHostile)
            {
                Fly();
                PerformSpecialAction();
                int damage = _random.Next(10, 20);
                base.Attack(target, damage);
            }
        }
    }
}