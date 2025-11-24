using System.Threading;
using System;

namespace Void.Entities.Characters
{

    public class Enemy : Entity
    {
       
        public Enemy(string name, int health, int damage, int range, int startPosition)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health;
            AttackDamage = damage;
            AttackRange = range;
            Position = startPosition;
        }

        public void PerformAction(Player player)
        {
            Console.WriteLine($"\nTurno de {Name}!");
            Thread.Sleep(1000);

            int distanceToPlayer = Math.Abs(this.Position - player.Position);

            if(distanceToPlayer <= this.AttackRange)
            {
                Console.WriteLine($"{Name} ataca {player.Name}");
                player.CurrentHealth -= this.AttackDamage;
                Console.WriteLine($"Você recebeu {this.AttackDamage} de dano.");
            }
            else
            {
                Console.WriteLine($"> {Name} se aproxima das sombras...");
                if (this.Position < player.Position)
                {
                    this.Position++;
                }
                else if(this.Position > player.Position)
                {
                    this.Position--;
                }
            }

                Console.WriteLine("> O inimigo observa você, planejando o próximo movimento.");
        }
    }
}
