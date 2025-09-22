using Void.Entities.Characters;
using Void.Systems.Combat;
using System;
using System.Threading;
using Spectre.Console;

namespace Void.Systems.Story
{
    public class PrologueEvent : IStoryEvent
    {
        
        public StoryResult Play()
        {
            Narrate("'Antes do som, houve o silêncio.", 2000);
            Narrate(" Antes da luz, a ausência.'\n", 2500);

            
            Narrate("O mundo não terminou com uma explosão, mas com um sussurro.", 2000);
            Narrate("Foi como se algo tivesse respirado fundo... e nunca mais expirado. \n", 3000);

            Narrate("Voc não sabe seu nome.", 1500);
            Narrate("Não se lembra de ter nascido.", 1500);
            Narrate("Mas sabe, de algum jeito, que está desperto agora. \n", 3000);

            Narrate("Mais à frente, uma luz fraca... cinza.", 2000);
            Narrate("Você caminha. \n", 2000);

            // Console.Clear();
            
            var systemPanel = new Panel("[lime]Terreno reconhecido: Fragmento da Origem[/]")
                .Border(BoxBorder.Rounded);
            AnsiConsole.Write(systemPanel);
            Thread.Sleep(3000);

            Narrate("\nVocê se aproxima de um pedestal. Há algo ali: um arco quebrado e uma marca gravada na pedra.", 2500);

            Narrate("\"Alara...\"", 3000);

            Narrate("Ao tocar o arco, imagens invadem sua cabe�a.", 2000);
            Narrate("Flechas cortando sombras. Uma mulher de cabelos prateados.", 2000);
            Narrate("Gritos. Corpos. E o sil�ncio de novo. \n", 3000);

            var alara = new Player("Alara", 100, 20, 3);
            alara.Skills.Add(new FlechaPerfurante());
            AnsiConsole.Write(new Panel("[cyan]\"Ela luta. Ela lembra. Ela existe em você.\"[/]")
                .Header("[white bold]Você desbloqueou a lembrança de Alara[/]")
                .Border(BoxBorder.Double)
                .BorderColor(Color.Cyan1));
            Thread.Sleep(3000);

            Console.Clear();

            Narrate("E então — som.", 1500);
            Narrate("Um ruído áspero, rastejante.", 2000);
            Narrate("Algo está vindo.", 3000);

            AnsiConsole.MarkupLine("[red]Sombra Rastejante detectada.[/]");
            Thread.Sleep(2500);

            var enemy = new Enemy("Sombra Rastejante", 40, 10, 1, 7);

            var result = new StoryResult
            {
                CharacterUnlocked = alara,
                EnemyToFight = enemy
            };

            return result;
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