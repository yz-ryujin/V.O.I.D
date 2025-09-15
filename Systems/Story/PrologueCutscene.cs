using Void.Entities.Characters;
using Void.Systems.Combat;
using System;
using System.Threading; // Para simular delays

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
            Narrate(" Antes da luz, a aus�ncia.�", 2500);

            Console.Clear();

            Narrate("O mundo n�o terminou com uma explos�o, mas com um sussurro.", 2000);
            Narrate("Foi como se algo tivesse respirado fundo... e nunca mais expirado.", 3000);

            Narrate("Voc� n�o sabe seu nome.", 1500);
            Narrate("N�o se lembra de ter nascido.", 1500);
            Narrate("Mas sabe � de algum jeito � que est� desperto agora.", 3000);

            Narrate("Mais � frente, uma luz fraca... cinza.", 2000);
            Narrate("Voc� caminha.", 2000);

            Console.Clear();

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Narrate("Terreno reconhecido: Fragmento da Origem \n", 3000);
            Console.ResetColor();

            Narrate("Voc� se aproxima de um pedestal. H� algo ali: um arco quebrado e uma marca gravada na pedra.", 2500);

            Narrate("\"Alara...\"", 3000);

            Narrate("Ao tocar o arco, imagens invadem sua cabe�a.", 2000);
            Narrate("Flechas cortando sombras. Uma mulher de cabelos prateados.", 2000);
            Narrate("Gritos. Corpos. E o sil�ncio de novo. \n", 3000);

            var alara = new Player("Alara", 100, 20, 3);

            // Atribuindo habilidade
            alara.Skills.Add(new FlechaPerfurante());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Narrate("[Voc� desbloqueou a lembran�a de Alara.]", 2000);
            Narrate("\"Ela luta. Ela lembra. Ela existe em voc�.\"", 3000);
            Console.ResetColor();

            return alara; // Retorna a personagem desbloqueada
        }

        private void Narrate(string text, int delayAfter = 1500)
        {
            Console.WriteLine(text);
            Thread.Sleep(delayAfter);
        }
    }
}