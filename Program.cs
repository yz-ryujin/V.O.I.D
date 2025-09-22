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
            gameManager.StartCampaign();

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}