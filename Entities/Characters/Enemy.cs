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

            Console.WriteLine("> O inimigo observa você, planejando o próximo movimento.");
        }
    }
}
