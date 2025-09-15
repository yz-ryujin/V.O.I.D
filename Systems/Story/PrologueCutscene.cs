using Void.Entities.Characters;
using Void.Systems.Combat;
using System;
using System.Threading; // Para simular delays
using Spectre.Console;

namespace Void.Systems.Story
{
    public class PrologueCutscene
    {
        /// <summary>
        /// Executa a cutscene do prólogo e retorna o personagem desbloqueado.
        /// </summary>
        public Player Play()
        {
            Narrate("“Antes do som, houve o silêncio.", 2000);
            Narrate(" Antes da luz, a ausência.”\n", 2500);

            
            Narrate("O mundo não terminou com uma explosão, mas com um sussurro.", 2000);
            Narrate("Foi como se algo tivesse respirado fundo... e nunca mais expirado. \n", 3000);

            Narrate("Você não sabe seu nome.", 1500);
            Narrate("Não se lembra de ter nascido.", 1500);
            Narrate("Mas sabe — de algum jeito — que está desperto agora. \n", 3000);

            Narrate("Mais à frente, uma luz fraca... cinza.", 2000);
            Narrate("Você caminha. \n", 2000);

            // Console.Clear();


            var systemPanel = new Panel("[lime]Terreno reconhecido: Fragmento da Origem[/]")
                .Border(BoxBorder.Rounded);
            AnsiConsole.Write(systemPanel);
            Thread.Sleep(3000);

            Narrate("\nVocê se aproxima de um pedestal. Há algo ali: um arco quebrado e uma marca gravada na pedra.", 2500);

            Narrate("\"Alara...\"", 3000);

            Narrate("Ao tocar o arco, imagens invadem sua cabeça.", 2000);
            Narrate("Flechas cortando sombras. Uma mulher de cabelos prateados.", 2000);
            Narrate("Gritos. Corpos. E o silêncio de novo. \n", 3000);

            var alara = new Player("Alara", 100, 20, 3);

            // Atribuindo habilidade
            alara.Skills.Add(new FlechaPerfurante());

            var unlockPanel = new Panel("[white bold]Você desbloqueou a lembrança de Alara[/] [cyan]\n Ela luta. Ela lembra. Ela existe em você.\"[/]")
                .Border(BoxBorder.Double)
                .BorderColor(Color.Cyan1);
            AnsiConsole.Write(unlockPanel);
            Thread.Sleep(3000);

            return alara; // Retorna a personagem desbloqueada
        }

        private void Narrate(string text, int delayAfter = 1500)
        {
            AnsiConsole.MarkupLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}