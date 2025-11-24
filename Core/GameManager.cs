using Void.Entities.Characters;
using Void.Core;
using Void.Systems.Combat;
using Void.Systems.Story;
using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;
using Void.Systems.Audio;

namespace Void.Core
{
    public class GameManager
    {
        private readonly List<Player> _unlockedCharacters;
        private readonly StoryManager _storyManager;

        public GameManager()
        {
            _unlockedCharacters = new List<Player>();
            _storyManager = new StoryManager();
        }

        public void StartCampaign()
        {

            var bannerLines = new[]
            {
                "                                                                            ",
                "                                                                            ",
                "                ██▒   █▓      ▒█████        ██▓     ▓█████▄                 ",
                "               ▓██░   █▒     ▒██▒  ██▒     ▓██▒     ▒██▀ ██▌                ",
                "                ▓██  █▒░     ▒██░  ██▒     ▒██▒     ░██   █▌                ",
                "                 ▒██ █░░     ▒██   ██░     ░██░     ░▓█▄   ▌                ",
                "                  ▒▀█░   ██▓ ░ ████▓▒░ ██▓ ░██░ ██▓ ░▒████▓                 ",
                "                  ░ ▐░   ▒▓▒ ░ ▒░▒░▒░  ▒▓▒ ░▓   ▒▓▒  ▒▒▓  ▒                 ",
                "                  ░ ░░   ░▒    ░ ▒ ▒░  ░▒   ▒ ░ ░▒   ░ ▒  ▒                 ",
                "                    ░░   ░   ░ ░ ░ ▒   ░    ▒ ░ ░    ░ ░  ░                 ",
                "                     ░    ░      ░ ░    ░   ░    ░     ░                    ",
                "                    ░     ░             ░        ░   ░                      ",
                "                                                                            "
            };

            var bannerText = string.Join("\n", bannerLines);

            AnsiConsole.Write(
                new Align(
                    new Markup($"[magenta3]{bannerText}[/]"),
                    HorizontalAlignment.Center
                )
            );

            AnsiConsole.MarkupLine("\n \n[grey]Pressione qualquer tecla para despertar...[/] \n");
            Console.ReadKey();

            AudioManager.PlayBackgroundMusic("void_theme.wav");


            StoryResult prologueResult = _storyManager.PlayPrologue();

            if (prologueResult.CharacterUnlocked != null && prologueResult.EnemyToFight != null)
            {
                Player alara = prologueResult.CharacterUnlocked;
                _unlockedCharacters.Add(alara);

                CombatManager combat1 = new CombatManager(alara, prologueResult.EnemyToFight);
                combat1.StartBattle();

                if (!alara.IsAlive)
                {
                    AnsiConsole.MarkupLine("\nO Véu te consumiu antes mesmo de sua história começar.");
                    return;
                }

                AnsiConsole.MarkupLine("\nVocê sobreviveu ao seu primeiro desafio no Vazio.");
                Narrate("...A jornada apenas começou.", 3000);
            }

            Console.Clear();
            StoryResult riftResult = _storyManager.PlayFirstRift();

            if (riftResult.CharacterUnlocked != null)
            {
                _unlockedCharacters.Add(riftResult.CharacterUnlocked);
            }

            Console.Clear();
            Narrate("Com uma nova memória resgatada do esquecimento, você sente o Vazio reagir...", 3000);
            AnsiConsole.MarkupLine("\n[red]Outra criatura se materializa, atraída pelo poder que você agora detém.[/]");
            Thread.Sleep(3000);

            Player selectedPlayer = ChooseCharacter();

            if (riftResult.EnemyToFight != null)
            { 
                Enemy secondEnemy = riftResult.EnemyToFight;

                CombatManager combat2 = new CombatManager(selectedPlayer, secondEnemy);
                combat2.StartBattle();

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

        private void Narrate(string text, int delayAfter = 1500)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(65);
            }
            Console.WriteLine();

            Thread.Sleep(delayAfter);
        }
    }
}