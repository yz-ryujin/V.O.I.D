using Void.Entities.Characters;
using Spectre.Console;
using System;
using System.Threading;

namespace Void.Systems.Story
{
    public class FirstRiftEvent : IStoryEvent
    {
        public StoryResult Play()
        {
            Console.Clear();
            Narrate("O silêncio que retorna é diferente. Mais pesado.", 2500);
            Narrate("E então, o chão treme.", 2000);
            Narrate("Não um tremor violento, mas uma vibração profunda, como o bater de um coração colossal despertando sob seus pés.", 4000);

            Narrate("À sua frente, onde a criatura estava, a escuridão começa a se distorcer.", 3000);

            var panel = new Panel("[red]Anomalia detectada: Primeira Fenda[/]")
                .Header("[grey]Mensagem na tela[/]")
                .Border(BoxBorder.Rounded);
            AnsiConsole.Write(panel);
            Thread.Sleep(3000);

            Narrate("\nNão é uma porta. É uma ferida.", 2000);
            Narrate("De dentro dela, você ouve o impensável: sons. Milhares deles, sobrepostos.", 3500);
            Narrate("Ao olhar para dentro da Fenda, a realidade se desfaz.", 3000);
            Console.Clear();

            Narrate("Você não está mais no Vazio. Está no epicentro de uma batalha impossível.", 3000);
            Narrate("E no centro, de costas um para o outro, lutando contra essa maré, estão duas figuras.", 3500);

            AnsiConsole.MarkupLine("[red bold]Tharok, a Fúria Inextinguível.[/]");
            Thread.Sleep(2000);
            AnsiConsole.MarkupLine("[cyan bold]Lyra, a Luz Guardiã.[/]");
            Thread.Sleep(3000);

            Narrate("\n[grey]\"Fragmentos de um todo... Ecos de poder...\"[/]", 2500);
            Narrate("[grey]\"A Fenda não pode sustentá-los. Um deve ser abandonado...\"[/]", 3500);

            AnsiConsole.WriteLine();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("A Fenda está colapsando. [yellow]A quem você vai se agarrar?[/]")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Alcançar o Guerreiro (Tharok)", "Alcançar a Guardiã (Lyra)"
                    }));

            if (choice == "Alcançar o Guerreiro (Tharok)")
            {
                // Fragmento do Tharok
                Console.Clear();
                Narrate("Sua mão atravessa a barreira da Fenda e se fecha sobre o eco de Tharok.", 3000);
                Narrate("Na visão, você vê Lyra olhar em sua direção. Não há medo em seus olhos, apenas aceitação.", 3500);
                Narrate("Seu cântico cessa, e a maré de sombras a consome instantaneamente.", 3000);

                var tharok = new Tharok();
                var unlockPanel = new Panel($"[yellow]\"O Vazio só entende uma linguagem: a força. Fale com ele em gritos e fogo, e ele aprenderá a temer você.\"[/]")
                    .Header($"[white bold]Você desbloqueou a lembrança de {tharok.Name}[/]")
                    .Border(BoxBorder.Double).BorderColor(Color.Yellow);
                AnsiConsole.Write(unlockPanel);
                Thread.Sleep(4000);

                return new StoryResult
                {
                    CharacterUnlocked = tharok,
                    EnemyToFight = new Enemy("Arauto da Loucura", 60, 15, 2, 8)
                };
            }
            else
            {
                // Fragmento da Lyra
                Console.Clear();
                Narrate("Sua mão atravessa a Fenda e se agarra ao eco de Lyra.", 3000);
                Narrate("Na visão, você vê o machado de Tharok finalmente vacilar. Ele encara a horda com um último sorriso desafiador.", 4000);
                Narrate("As sombras o engolem, e sua chama negra se apaga na escuridão infinita.", 3000);

                var lyra = new Lyra();
                var unlockPanel = new Panel($"[cyan]\"Não se vence a escuridão com mais escuridão. Vence-se sendo a luz que, por menor que seja, se recusa a apagar.\"[/]")
                    .Header($"[white bold]Você desbloqueou a lembrança de {lyra.Name}[/]")
                    .Border(BoxBorder.Double).BorderColor(Color.Cyan1);
                AnsiConsole.Write(unlockPanel);
                Thread.Sleep(4000);

                return new StoryResult 
                { 
                    CharacterUnlocked = lyra,
                    EnemyToFight = new Enemy("Arauto da Loucura", 60, 15, 2, 8)
                };
            }
        }

        private void Narrate(string text, int delayAfter = 1500)
        {
            AnsiConsole.MarkupLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}