using Void.Entities.Characters;

namespace Void.Systems.Story
{
    public class StoryResult
    {
        public Player? CharacterUnlocked { get; set; }
        public Enemy? EnemyToFight { get; set; }

    }
}