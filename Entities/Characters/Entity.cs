namespace Void.Entities.Characters
{
    public abstract class Entity
    {
        public string Name { get; protected set; } = string.Empty;
        public int MaxHealth { get; protected set; }
        public int CurrentHealth { get; set; }
        public int AttackDamage { get; protected set; }
        public int AttackRange { get; protected set; }
        public int Position { get; set; }    

        public bool IsAlive => CurrentHealth > 0;
    }
}


