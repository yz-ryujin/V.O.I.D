using Void.Entities.Characters;
using Void.Core;
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
        private readonly StoryManager _storyManager;

        public GameManager()
        {
            _unlockedCharacters = new List<Player>();
            _storyManager = new StoryManager();
        }

        public void StartCampaign()
        {           

            var arcaneEchoArt = AssetManager.Load("EcoArcano.txt");

            
            var layout = new Layout("Root")
                .SplitRows(
                    new Layout("Top").Ratio(3), 
                    new Layout("Bottom").Ratio(1)
                );

            
            string asciiArtString = string.Join("\n", arcaneEchoArt);
            var asciiArtPanel = new Panel(new Text(asciiArtString).Centered())
                .Expand()
                .Border(BoxBorder.Double) 
                .BorderColor(Color.White);

            
            layout["Top"].Update(asciiArtPanel);

            
            var descriptionText = "\n[grey]> O ar é pesado, carregado com o pó de eras esquecidas.\n> O silêncio é tão profundo que você quase ouve o estalar de sua própria alma.[/]\n" +
                      "[grey]> Através da névoa de partículas, uma figura alta se define, imóvel como uma estátua.\n> Runas que você não reconhece pulsam com uma luz fraca em suas vestes, tecendo padrões de poder há muito perdido.                         [/]\n\n" +
                      "[white bold]UM ECO ARCANO[/] está diante de você, um guardião silencioso do nada.";
            var actionsText = "\n[gold1]» Attack[/]\n  Item\n  Look\n  Flee\n";

            var grid = new Grid();

            
            grid.AddColumn(); 
            grid.AddColumn(new GridColumn().Width(10)); 
            grid.AddRow(
                new Markup(descriptionText), 
                new Markup(actionsText)  
            );

            var bottomPanel = new Panel(grid)
                .Expand()
                .Header("[red1]Combate[/]")
                .Border(BoxBorder.Double)
                .BorderColor(Color.Grey50);

            layout["Bottom"].Update(bottomPanel);

            AnsiConsole.Write(layout);

            AnsiConsole.MarkupLine("\n \n[grey]Pressione qualquer tecla para despertar...[/] \n");
            Console.ReadKey();
            Console.Clear();

            
            // 1. Tocar a cutscene do prólogo
            StoryResult result = _storyManager.StartStory();

            Player activePlayer = result.CharacterUnlocked;

            if (activePlayer != null)
            {
                _unlockedCharacters.Add(activePlayer);
            }

            if (result.EnemyToFight != null)
            {
                CombatManager combat = new CombatManager(activePlayer, result.EnemyToFight);
                combat.StartBattle();
            }

            if (activePlayer.IsAlive)
            {
                Console.WriteLine("\nVocê sobreviveu ao encontro inicial com o Vazio.");
            }
            else
            {
                Console.WriteLine("\nO Véu te consumiu antes mesmo de sua história começar.");
                return;
            }


            Console.Clear();


            Narrate("Seguindo um rastro de energia distorcida, você encontra outra ilha flutuante", 2000);
            Narrate("Nela, um homem de armadura pesada luta sozinho contra três sombras.", 3000);
            Narrate("Com sua ajuda, a batalha termina rapidamente", 2000);

            AnsiConsole.MarkupLine("\n [yellow]\" Essa escória não para de surgir. Sou Tarok. Parece que temos um inimigo em comum.\"[/]");
            Thread.Sleep(3500);

            var tharok = new Tharok();
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

        private void Narrate(string text, int delayAfter = 1500)
        {
            Console.WriteLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}