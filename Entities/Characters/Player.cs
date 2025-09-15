using System;
using Void.Systems.Combat;
using System.Collections.Generic;


namespace Void.Entities.Characters
{
    // Classe Player que herda de Entity
    public class Player : Entity
    {

        // Nova Propriedade: Uma lista para guardar todas as habilidades do personagem.
        public List<Skill> Skills { get; private set; }

        // Construtor da classe Player
        public Player(string name, int health, int damage, int range)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health; // Começa com a vida cheia
            AttackDamage = damage;
            AttackRange = range;
            Position = 2; // Posição inicial do jogador

            Skills = new List<Skill>();
        }
    }
}