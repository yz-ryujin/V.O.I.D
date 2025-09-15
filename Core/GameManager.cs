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
                return;
            }

            Console.Clear();


            Narrate("Seguindo um rastro de energia distorcida, você encontra outra ilha flutuante", 2000) ;
            Narrate("Nela, um homem de armadura pesada luta sozinho contra três sombras.", 3000);
            Narrate("Com sua ajuda, a batalha termina rapidamente", 2000);

            AnsiConsole.MarkupLine("\n [yellow]\" Essa escória não para de surgir. Sou Tarok. Parece que temos um inimigo em comum.\"[/]");
            Thread.Sleep(3500);

            // Desbloqueio de Tharok
            var tharok = new Tharok(); // Criar uma instância de Tharok
            _unlockedCharacters.Add(tharok);

            var unlockPanel = new Panel($"\n [cyan]O poder e a resiliência de Tharok agora são seus.[/]")
                .Header($"[white bold]Você desbloqueou a lembrança de {tharok.Name}[/]")
                .Border(BoxBorder.Double)
                .BorderColor(Color.Cyan1);
            AnsiConsole.Write(unlockPanel);
            Thread.Sleep(3000);

            Console.Clear();

            Narrate("Um novo desafio se aproxima nas brumas do Vazio...", 2500);

            Player selectedPlayer = ChooseCharacter();

            AnsiConsole.MarkupLine($"\n[red]Arauto da Loucura[/] detectado!");
            Thread.Sleep(2000);
            Enemy secondEnemy = new Enemy("Arauto da Loucura", 60, 15, 2, 8);

            CombatManager combat2 = new CombatManager(selectedPlayer, secondEnemy);
            combat2.StartBattle();

            if (selectedPlayer.IsAlive)
            {
                AnsiConsole.MarkupLine("\nOutra vitória... mas a um custo. O Vazio parece mais denso.");
            }
            else
            {
                AnsiConsole.MarkupLine($"\nA mente de {selectedPlayer.Name} foi quebrada pela loucura.");
            }

        }

        private Player ChooseCharacter()
        {
            AnsiConsole.WriteLine();

            var prompt = new SelectionPrompt<Player>()
                .Title("Qual [yellow]campeão[/] enfrentará o Vazio?")
                .PageSize(5)
                .MoreChoicesText("[grey](Mova para cima e para baixo para ver mais opções)[/]")
                .UseConverter(player => $"[bold]{player.Name}[/] [grey](HP: {player.MaxHealth}, Dano: {player.AttackDamage}, Alcance: {player.AttackRange})[/]");

            
            prompt.AddChoices(_unlockedCharacters);
                       
            return AnsiConsole.Prompt(prompt);
        }

        // Método auxiliar que movemos para cá para ser usado pelo GameManager
        private void Narrate(string text, int delayAfter = 1500)
        {
            Console.WriteLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}