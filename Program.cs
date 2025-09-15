using System;
using Void.Entities.Characters;
using Void.Systems.Combat;
using Void.Core;

namespace Void
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.StartCampaing();

            // Espera o usuário pressionar uma tecla antes de sair
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}