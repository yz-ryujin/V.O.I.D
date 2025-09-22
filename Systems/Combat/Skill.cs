using System;
using Void.Entities.Characters;

namespace Void.Systems.Combat
{

    public abstract class Skill
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Damage { get; protected set; }
                
        public Skill(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Damage = damage;
        }

        public abstract void Execute(Entity user, Entity target);
    }
}


