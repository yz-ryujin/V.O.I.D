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
        /// Executa a cutscene do pr�logo e retorna o personagem desbloqueado.
        /// </summary>
        public Player Play()
        {
            Narrate("�Antes do som, houve o sil�ncio.", 2000);
            Narrate(" Antes da luz, a aus�ncia.�\n", 2500);

            
            Narrate("O mundo n�o terminou com uma explos�o, mas com um sussurro.", 2000);
            Narrate("Foi como se algo tivesse respirado fundo... e nunca mais expirado. \n", 3000);

            Narrate("Voc� n�o sabe seu nome.", 1500);
            Narrate("N�o se lembra de ter nascido.", 1500);
            Narrate("Mas sabe � de algum jeito � que est� desperto agora. \n", 3000);

            Narrate("Mais � frente, uma luz fraca... cinza.", 2000);
            Narrate("Voc� caminha. \n", 2000);

            // Console.Clear();
            
            var systemPanel = new Panel("[lime]Terreno reconhecido: Fragmento da Origem[/]")
                .Border(BoxBorder.Rounded);
            AnsiConsole.Write(systemPanel);
            Thread.Sleep(3000);

            Narrate("\nVoc� se aproxima de um pedestal. H� algo ali: um arco quebrado e uma marca gravada na pedra.", 2500);

            Narrate("\"Alara...\"", 3000);

            Narrate("Ao tocar o arco, imagens invadem sua cabe�a.", 2000);
            Narrate("Flechas cortando sombras. Uma mulher de cabelos prateados.", 2000);
            Narrate("Gritos. Corpos. E o sil�ncio de novo. \n", 3000);

            var alara = new Player("Alara", 100, 20, 3);

            // Atribuindo habilidade
            alara.Skills.Add(new FlechaPerfurante());

            var unlockPanel = new Panel("[white bold]Voc� desbloqueou a lembran�a de Alara[/] [cyan]\n Ela luta. Ela lembra. Ela existe em voc�.\"[/]")
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