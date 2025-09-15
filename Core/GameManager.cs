using Void.Entities.Characters;
using Void.Systems.Story;
using System;
using System.Collections.Generic;

namespace Void.Core
{
    public class GameManager
    {
        private readonly List<Player> _unlockedCharacters;

        public GameManager()
        {
            _unlockedCharacters = new List<Player>();
        }

        public void StartCampaign()
        {
            // 1. Tocar a cutscene do prólogo
            PrologueCutscene prologue = new PrologueCutscene();
            Player unlockedCharacter = prologue.Play();

            // 2. Adicionar o personagem retornado à lista de desbloqueados
            _unlockedCharacters.Add(unlockedCharacter);

            Console.WriteLine($"\n{unlockedCharacter.Name} foi adicionada ao seu time.");
            // O combate começará aqui no próximo passo...
        }
    }
}