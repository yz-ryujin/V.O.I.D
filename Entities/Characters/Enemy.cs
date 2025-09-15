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
            CurrentHealth = health; // Come�a com a vida cheia
            AttackDamage = damage;
            AttackRange = range;
            Position = startPosition; // Posi��o inicial do inimigo
        }

        public void PerformAction(Player player)
        {
            Console.WriteLine($"\nTurno de {Name}!");
            Thread.Sleep(1000); // Simula um delay para a a��o do inimigo

            Console.WriteLine("> O inimigo observa voc�, planejando o pr�ximo movimento.");
        }
    }
}
