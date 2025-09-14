using System;
using Void.Entities.Characters;
using Void.Systems.Combat;

namespace Void
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criação do jogador e inimigo
            Player player = new Player("Tharok", 140, 25, 1);
            Enemy enemy = new Enemy("Sombra Rastejante", 40, 10, 1, 7);

            // Gerenciamento do combate
            CombatManager combatManager = new CombatManager(player, enemy);

            // Início do combate
            combatManager.StartBattle();

            // Espera o usuário pressionar uma tecla antes de sair
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}