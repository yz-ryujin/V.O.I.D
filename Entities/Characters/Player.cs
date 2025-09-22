using System;
using Void.Systems.Combat;
using System.Collections.Generic;


namespace Void.Entities.Characters
{
    public class Player : Entity
    {
        public List<Skill> Skills { get; private set; }

        public Player(string name, int health, int damage, int range)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health;
            AttackDamage = damage;
            AttackRange = range;
            Position = 2;

            Skills = new List<Skill>();
        }
    }
}