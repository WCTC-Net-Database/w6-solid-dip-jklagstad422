using System;
using System.Collections.Generic;
using System.Linq;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly ICharacter _player;
        private readonly IEnumerable<ICharacter> _enemies;
        private bool _isGameOver = false;

   
        public GameEngine(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _player = context.Characters.FirstOrDefault(c => c.Class == "Adventurer")
                             ?? throw new InvalidOperationException("No player found in context.");

            _enemies = context.Characters.Where(c => c != _player).ToList();
        }

        public void Run()
        {
          

            Console.WriteLine("Welcome to the RPG Game!");

            while (!_isGameOver)
            {
                // ... (DisplayStatus call)

                Console.Write("Choose action (1-Attack, 2-Heal, 3-Special): ");
                var input = Console.ReadLine()?.Trim();

                var targetEnemy = _enemies.FirstOrDefault(e => e.HitPoints > 0);

                if (targetEnemy != null)
                {
                    switch (input)
                    {
                        case "1": PlayerAttack(targetEnemy); break;
                        case "2": PlayerHeal(); break;
                        case "3": _player.PerformSpecialAction(); break;
                        default: Console.WriteLine("Invalid choice!"); break;
                    }

                    foreach (var enemy in _enemies.Where(e => e.HitPoints > 0))
                    {
                        enemy.TakeTurn(_player);
                    }
                }
       
            }
            Console.WriteLine("Game Over!");
        }


        private void PlayerAttack(ICharacter target)
        {
            if (_player is Player concretePlayer)
            {
                concretePlayer.Attack(target);
            }
        }

        private void PlayerHeal()
        {
            if (_player is Player concretePlayer)
            {
                concretePlayer.Heal();
            }
        }
    }
}