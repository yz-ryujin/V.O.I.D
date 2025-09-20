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
            Narrate("O sil�ncio que retorna � diferente. Mais pesado.", 2500);
            Narrate("E ent�o, o ch�o treme.", 2000);
            Narrate("N�o um tremor violento, mas uma vibra��o profunda, como o bater de um cora��o colossal despertando sob seus p�s.", 4000);

            Narrate("� sua frente, onde a criatura estava, a escurid�o come�a a se distorcer.", 3000);

            var panel = new Panel("[red]Anomalia detectada: Primeira Fenda[/]")
                .Header("[grey]Mensagem na tela[/]")
                .Border(BoxBorder.Rounded);
            AnsiConsole.Write(panel);
            Thread.Sleep(3000);

            Narrate("\nN�o � uma porta. � uma ferida.", 2000);
            Narrate("De dentro dela, voc� ouve o impens�vel: sons. Milhares deles, sobrepostos.", 3500);
            Narrate("Ao olhar para dentro da Fenda, a realidade se desfaz.", 3000);
            Console.Clear();

            Narrate("Voc� n�o est� mais no Vazio. Est� no epicentro de uma batalha imposs�vel.", 3000);
            Narrate("E no centro, de costas um para o outro, lutando contra essa mar�, est�o duas figuras.", 3500);

            AnsiConsole.MarkupLine("[red bold]Tharok, a F�ria Inextingu�vel.[/]");
            Thread.Sleep(2000);
            AnsiConsole.MarkupLine("[cyan bold]Lyra, a Luz Guardi�.[/]");
            Thread.Sleep(3000);

            Narrate("\n[grey]\"Fragmentos de um todo... Ecos de poder...\"[/]", 2500);
            Narrate("[grey]\"A Fenda n�o pode sustent�-los. Um deve ser abandonado...\"[/]", 3500);

            AnsiConsole.WriteLine();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("A Fenda est� colapsando. [yellow]A quem voc� vai se agarrar?[/]")
                    .PageSize(3)
                    .AddChoices(new[] {
                        "Alcan�ar o Guerreiro (Tharok)", "Alcan�ar a Guardi� (Lyra)"
                    }));

            if (choice == "Alcan�ar o Guerreiro (Tharok)")
            {
                // Fragmento do Tharok
                Console.Clear();
                Narrate("Sua m�o atravessa a barreira da Fenda e se fecha sobre o eco de Tharok.", 3000);
                Narrate("Na vis�o, voc� v� Lyra olhar em sua dire��o. N�o h� medo em seus olhos, apenas aceita��o.", 3500);
                Narrate("Seu c�ntico cessa, e a mar� de sombras a consome instantaneamente.", 3000);

                var tharok = new Tharok();
                var unlockPanel = new Panel($"[yellow]\"O Vazio s� entende uma linguagem: a for�a. Fale com ele em gritos e fogo, e ele aprender� a temer voc�.\"[/]")
                    .Header($"[white bold]Voc� desbloqueou a lembran�a de {tharok.Name}[/]")
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
                Narrate("Sua m�o atravessa a Fenda e se agarra ao eco de Lyra.", 3000);
                Narrate("Na vis�o, voc� v� o machado de Tharok finalmente vacilar. Ele encara a horda com um �ltimo sorriso desafiador.", 4000);
                Narrate("As sombras o engolem, e sua chama negra se apaga na escurid�o infinita.", 3000);

                var lyra = new Lyra();
                var unlockPanel = new Panel($"[cyan]\"N�o se vence a escurid�o com mais escurid�o. Vence-se sendo a luz que, por menor que seja, se recusa a apagar.\"[/]")
                    .Header($"[white bold]Voc� desbloqueou a lembran�a de {lyra.Name}[/]")
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