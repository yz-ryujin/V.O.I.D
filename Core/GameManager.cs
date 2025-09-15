using Void.Entities.Characters;
using Void.Systems.Combat;
using Void.Systems.Story;
using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;

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
            

            var bannerLines = new[]
            {
                " ██▒   █▓      ▒█████        ██▓     ▓█████▄ ",
                "▓██░   █▒     ▒██▒  ██▒     ▓██▒     ▒██▀ ██▌",
                " ▓██  █▒░     ▒██░  ██▒     ▒██▒     ░██   █▌",
                "  ▒██ █░░     ▒██   ██░     ░██░     ░▓█▄   ▌",
                "   ▒▀█░   ██▓ ░ ████▓▒░ ██▓ ░██░ ██▓ ░▒████▓ ",
                "   ░ ▐░   ▒▓▒ ░ ▒░▒░▒░  ▒▓▒ ░▓   ▒▓▒  ▒▒▓  ▒ ",
                "   ░ ░░   ░▒    ░ ▒ ▒░  ░▒   ▒ ░ ░▒   ░ ▒  ▒ ",
                "     ░░   ░   ░ ░ ░ ▒   ░    ▒ ░ ░    ░ ░  ░ ",
                "      ░    ░      ░ ░    ░   ░    ░     ░    ",
                "     ░     ░             ░        ░   ░      "
            };


            // Obter largura do console
            int consoleWidth = Console.WindowWidth;

            foreach (var line in bannerLines)
            {
                int leftPadding = (consoleWidth - line.Length) / 2;
                string paddedLine = new string(' ', Math.Max(0, leftPadding)) + line;
                AnsiConsole.WriteLine(paddedLine);
            }

            



            AnsiConsole.MarkupLine("\n \n[grey]Pressione qualquer tecla para despertar...[/] \n");
            Console.ReadKey();

            // 1. Tocar a cutscene do prólogo
            PrologueCutscene prologue = new PrologueCutscene();
            Player activePlayer = prologue.Play();

            // 2. Adicionar o personagem retornado à lista de desbloqueados
            _unlockedCharacters.Add(activePlayer);

            Console.WriteLine($"\n{activePlayer.Name} foi adicionada ao seu time.");
            Thread.Sleep(2000);

            // 3. Preparar e iniciar o primeiro combate
            Narrate("E então — som.", 1500);
            Narrate("Um ruído áspero, rastejante.", 2000);
            Narrate("Algo está vindo. \n", 3000);

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
                Console.WriteLine("\nVocê sobreviveu ao seu primeiro desafio no Vazio.");
                Narrate("...A jornada apenas começou.", 3000);
            }
            else
            {
                Console.WriteLine("\nO Véu te consumiu antes mesmo de sua história começar.");
            }
        }

        // Método auxiliar que movemos para cá para ser usado pelo GameManager
        private void Narrate(string text, int delayAfter = 1500)
        {
            Console.WriteLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}