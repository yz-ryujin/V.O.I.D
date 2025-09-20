
using Void.Entities.Characters;
using System;
using System.Threading; // Para simular delays
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Void.Systems.Combat
{
    public class CombatManager
    {
        private readonly Player _player;
        private readonly Enemy _enemy;
        private readonly char[] _terrain;
        private bool _isPlayerTurn = true;

        public CombatManager(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            _terrain = new char[10];
        }

        public void StartBattle()
        {
            while (_player.IsAlive && _enemy.IsAlive)
            {
                // Desenha o campo de batalha e HUD
                DrawBattlefield();
                DisplayHUD();

                if (_isPlayerTurn)
                {
                    var rule = new Rule($"[yellow bold]Turno de {_player.Name}[/]");
                    rule.Justification = Justify.Left;
                    AnsiConsole.Write(rule);
                    // Mecanismo de ação do jogador
                    HandlePlayerAction();
                }
                else
                {
                    var rule = new Rule($"[red bold]Turno de {_enemy.Name}[/]");
                    rule.Justification = Justify.Left;
                    AnsiConsole.Write(rule);
                    _enemy.PerformAction(_player);
                }

                _isPlayerTurn = !_isPlayerTurn; // Alterna o turno

                if(_enemy.IsAlive)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            }

            // Exibe o resultado da batalha
            DisplayBattleResult();
        }

        private void HandlePlayerAction()
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\n[yellow]Qual sua próxima ação?[/]")
                    .PageSize(4)
                    .AddChoices(new[] {
                "Mover para Esquerda", "Mover para Direita", "Ataque Básico", "Usar Habilidade"
                    }));

            switch (choice)
            {
                case "Mover para Esquerda":
                    if (_player.Position > 0) { _player.Position--; AnsiConsole.MarkupLine("> Você se move para a [cyan]esquerda[/]."); }
                    else { AnsiConsole.MarkupLine("[grey]> Você já está no limite do campo![/]"); }
                    break;

                case "Mover para Direita":
                    if (_player.Position < _terrain.Length - 1) { _player.Position++; AnsiConsole.MarkupLine("> Você avança para a [cyan]direita[/]."); }
                    else { AnsiConsole.MarkupLine("[grey]> Você não pode mais avançar![/]"); }
                    break;

                case "Ataque Básico":
                    int distanceToEnemy = Math.Abs(_player.Position - _enemy.Position);
                    if (distanceToEnemy <= _player.AttackRange) { AnsiConsole.MarkupLine($"> Você ataca ferozmente a {_enemy.Name}!"); _enemy.CurrentHealth -= _player.AttackDamage; AnsiConsole.MarkupLine($"> O inimigo sofreu [red]{_player.AttackDamage}[/] de dano."); }
                    else { AnsiConsole.MarkupLine("[grey]> O inimigo está fora de alcance![/]"); }
                    break;

                case "Usar Habilidade":
                    HandleSkillUsage();
                    break;
            }
        }
        
        private void HandleSkillUsage()
        {
            if (!_player.Skills.Any())
            {
                AnsiConsole.MarkupLine("[grey]> Você não conhece nenhuma habilidade![/]");
                return;
            }

            Console.WriteLine("\nEscolha uma habilidade para usar:");

            var chosenSkill = AnsiConsole.Prompt(
                new SelectionPrompt<Skill>()
                    .Title("Qual [purple_1]habilidade[/] usar?")
                    .PageSize(5)
                    .MoreChoicesText("[grey](Navegue com as setas)[/]")
                    .UseConverter(skill => $"[bold]{skill.Name}[/] [grey]({skill.Description})[/]")
                    .AddChoices(_player.Skills));

            chosenSkill.Execute(_player, _enemy);
        }

        // --- MÉTODOS DE RENDERIZAÇÃO ---

        private void DrawBattlefield()
        {
            Console.Clear();
            Console.WriteLine("--- CAMPO DE BATALHA ---");

            for (int i = 0; i < _terrain.Length; i++)
            {
                _terrain[i] = '_';
            }

            _terrain[_player.Position] = 'P';
            _terrain[_enemy.Position] = 'E';

            Console.Write("Posição: ");
            for (int i = 0; i < _terrain.Length; i++)
            {
                Console.Write($"[{_terrain[i]}]");
            }
            Console.WriteLine("\n");
        }

        private void DisplayHUD()
        {
            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.Title("[yellow]STATUS DA BATALHA[/]");

            // Adicionamos uma largura à coluna da vida para a barra caber confortavelmente
            table.AddColumn(new TableColumn("[b]Personagem[/]").Centered());
            table.AddColumn(new TableColumn("[green]Vida[/]").Width(20).Centered()); // <-- LARGURA ADICIONADA
            table.AddColumn(new TableColumn("[cyan]Posição[/]").Centered());

            // --- Barra de Vida do Jogador ---
            var playerHealthChart = new BreakdownChart()
                .Width(18)
                .AddItem("Vida", _player.CurrentHealth, Color.Green)
                .AddItem("Dano", _player.MaxHealth - _player.CurrentHealth, Color.Grey15);

            // --- Barra de Vida do Inimigo ---
            var enemyHealthChart = new BreakdownChart()
                .Width(18)
                .AddItem("Vida", _enemy.CurrentHealth, Color.Red)
                .AddItem("Dano", _enemy.MaxHealth - _enemy.CurrentHealth, Color.Grey15);

            var playerRow = new List<IRenderable>
            {
                new Markup($"[b]{_player.Name}[/]"),
                playerHealthChart,
                new Markup($"[cyan]{_player.Position}[/]")
            };

                    var enemyRow = new List<IRenderable>
            {
                new Markup($"[b]{_enemy.Name}[/]"),
                enemyHealthChart,
                new Markup($"[cyan]{_enemy.Position}[/]")
            };

            
            table.AddRow(playerRow);
            table.AddRow(enemyRow);

            AnsiConsole.Write(table);
        }

        private void DisplayBattleResult()
        {
            Console.Clear();
            if (_player.IsAlive)
            {
                Console.WriteLine($"******************** \n VITÓRIA! \n ******************** ");
                Console.WriteLine($"Você derrotou {_enemy.Name}. ");
            }
            else
            {
                Console.WriteLine($"******************** \n DERROTA! \n ******************** ");
                Console.WriteLine($"Você foi consumido pelo Vazio. ");
            }
        }
    }
}