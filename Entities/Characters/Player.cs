namespace Void.Entities.Characters
{
    // Classe Player que herda de Entity
    public class Player : Entity
    {
        // Construtor da classe Player
        public Player(string name, int health, int damage, int range)
        {
            Name = name;
            MaxHealth = health;
            CurrentHealth = health; // Come�a com a vida cheia
            AttackDamage = damage;
            AttackRange = range;
            PositionX = 2; // Posi��o inicial do jogador
        }
    }
}