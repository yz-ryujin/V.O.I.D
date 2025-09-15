using Void.Entities.Characters;
using Void.Systems.Combat;
using Void.Systems.Story;
using System;
using System.Collections.Generic;
using System.Threading;

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
            // 1. Tocar a cutscene do pr�logo
            PrologueCutscene prologue = new PrologueCutscene();
            Player activePlayer = prologue.Play();

            // 2. Adicionar o personagem retornado � lista de desbloqueados
            _unlockedCharacters.Add(activePlayer);

            Console.WriteLine($"\n{activePlayer.Name} foi adicionada ao seu time.");
            Thread.Sleep(2000);
            Console.Clear();

            // 3. Preparar e iniciar o primeiro combate
            Narrate("E ent�o � som.", 1500);
            Narrate("Um ru�do �spero, rastejante.", 2000);
            Narrate("Algo est� vindo. \n", 3000);

            Console.ForegroundColor = ConsoleColor.Red;
            Narrate("Sombra Rastejante detectada.", 2500);
            Console.ResetColor();

            Enemy firstEnemy = new Enemy("Sombra Rastejante", 40, 10, 1, 7);

            // 4. Entregar o controle ao CombatManager
            CombatManager combat = new CombatManager(activePlayer, firstEnemy);
            combat.StartBattle();

            // 5. Lidar com o resultado da batalha
            if (activePlayer.IsAlive)
            {
                Console.WriteLine("\nVoc� sobreviveu ao seu primeiro desafio no Vazio.");
                Narrate("...A jornada apenas come�ou.", 3000);
            }
            else
            {
                Console.WriteLine("\nO V�u te consumiu antes mesmo de sua hist�ria come�ar.");
            }
        }

        // M�todo auxiliar que movemos para c� para ser usado pelo GameManager
        private void Narrate(string text, int delayAfter = 1500)
        {
            Console.WriteLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}