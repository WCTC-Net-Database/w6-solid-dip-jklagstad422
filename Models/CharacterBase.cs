using System;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{

    public abstract class CharacterBase : ICharacter
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public string Class { get; protected set; }
        public int Level { get; set; }

        protected IRoom CurrentRoom { get; set; }

        protected CharacterBase(string name, int hitPoints, string characterClass, int level, IRoom startingRoom)
        {
            Name = name;
            HitPoints = hitPoints;
            Class = characterClass;
            Level = level;
            CurrentRoom = startingRoom;
            CurrentRoom?.Enter();
        }

        public void MoveToRoom(IRoom room)
        {
            CurrentRoom = room;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} has entered {CurrentRoom.Name}. {CurrentRoom.Description}");
            Console.ResetColor();
        }

        public void Attack(ICharacter target, int damage)
        {
            target.HitPoints = Math.Max(target.HitPoints - damage, 0);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
        }

        public void Heal(int healAmount)
        {
            HitPoints += healAmount;
            Console.WriteLine($"{Name} heals for {healAmount} HP!");
        }

        public abstract void PerformSpecialAction();
        public abstract void TakeTurn(ICharacter target);
    }
}