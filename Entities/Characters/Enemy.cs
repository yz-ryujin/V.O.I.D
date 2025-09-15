using System.Threading;
using System;

namespace Void.Entities.Characters
{
    // Classe Enemy que herda de Entity

    public class Enemy : Entity
    {
        // Construtor da classe Enemy
       
        public Enemy(string name, int health, int damage, int range, int startPosition)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health; // Começa com a vida cheia
            AttackDamage = damage;
            AttackRange = range;
            Position = startPosition; // Posição inicial do inimigo
        }

        public void PerformAction(Player player)
        {
            Console.WriteLine($"\nTurno de {Name}!");
            Thread.Sleep(1000); // Simula um delay para a ação do inimigo

            // 1. Verifica se o jogador está ao alcance
            int distanceToPlayer = Math.Abs(this.Position - player.Position);

            // 2. Se estiver ao alcance, ataca
            if(distanceToPlayer <= this.AttackRange)
            {
                Console.WriteLine($"{Name} ataca {player.Name}");
                player.CurrentHealth -= this.AttackDamage;
                Console.WriteLine($"Você recebeu {this.AttackDamage} de dano.");
            }
            else
            {
                // 3. Se não, move-se em direção ao jogador
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
