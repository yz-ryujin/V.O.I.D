namespace Void.Entities.Characters
{
    public abstract class Entity
    {
        // Properties common to all entities
        public string Name { get; protected set; } // Name of the entity
        public int MaxHealth { get; protected set; } // Maximum health of the entity
        public int CurrentHealth { get; set; } // Current health of the entity
        public int AttackDamage { get; protected set; } // Attack damage of the entity
        public int AttackRange { get; protected set; } // Attack range of the entity
        public int PositionX { get; set; } // X position of the entity   

        public bool IsAlive => CurrentHealth > 0; // Check if the entity is alive
    }
}


/* A class foi definida como abstrata pois ela será apenas um molde para os demais personagens */