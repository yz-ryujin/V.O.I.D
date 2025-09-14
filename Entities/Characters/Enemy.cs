namespace Void.Entities.Characters
{
    // Classe Enemy que herda de Entity

    public class Entities : Entity
    {
        // Construtor da classe Enemy
       
        public Entities(string name, int health, int damage, int range, int startPosition)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health; // Come�a com a vida cheia
            AttackDamage = damage;
            AttackRange = range;
            PositionX = startPosition; // Posi��o inicial do inimigo
        }
    }
}