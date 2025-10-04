using System;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Player : CharacterBase
    {
        private readonly Random _random = new Random();


        public int Gold { get; set; }

        public Player(string name, int hitPoints, int level, IRoom startingRoom)
            : base(name, hitPoints, "Adventurer", level, startingRoom)
        {
            Gold = 10;
        }

     
        public Player() : base(string.Empty, 0, "Adventurer", 1, null) { }

        public override void PerformSpecialAction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} performs a tactical retreat, increasing defense for one turn!");
            Console.ResetColor();
        }

        public override void TakeTurn(ICharacter target) { }

        public void Attack(ICharacter target)
        {
            int damage = _random.Next(5, 15);
            base.Attack(target, damage);
        }

        public void Heal()
        {
            int heal = _random.Next(5, 10);
            base.Heal(heal);
        }
    }
}