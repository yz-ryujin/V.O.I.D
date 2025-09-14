
using Void.Entities.Characters;
using System;
using System.Threading; // Para simular delays

namespace Void.Systems.Combat
{
    public class CombatManager
    {
        private readonly Player _player;
        private readonly Enemy _enemy;
        private readonly char[] _terrain;
        private bool _isPlayerTurn = true; // Controla de quem � o turno

        // --- CONSTRUTOR ---
        public CombatManager(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            _terrain = new char[10];
        }

        // --- M�TODOS PRINCIPAIS ---
        public void StartBattle()
        {
            // Loop continuar� enquanto estiverem vivos
            while (_player.IsAlive && _enemy.IsAlive)
            {
                // Desenha o campo de batalha e HUD
                DrawBattlefield();
                DisplayHUD();

                // Verifica de quem � o turno
                if (_isPlayerTurn)
                {
                    Console.WriteLine("\nSeu turno! (A��es ainda n�o implementadas)");
                }
                else
                {
                    Console.WriteLine($"\nTurno de {_enemy.Name}! (IA ainda n�o implementada)");
                }

                _isPlayerTurn = !_isPlayerTurn; // Alterna o turno

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            // Futuramente: DisplayBattleResult();
            Console.WriteLine("A batalha terminou!");
        }

        // --- M�TODOS DE RENDERIZA��O ---

        private void DrawBattlefield()
        {
            Console.Clear();
            Console.WriteLine("--- CAMPO DE BATALHA ---");

            for (int i = 0; i < _terrain.Length; i++)
            {
                _terrain[i] = '.'; // Limpa o terreno
            }

            _terrain[_player.Position] = 'P';
            _terrain[_enemy.Position] = 'E';

            Console.Write("Posi��o: ");
            for (int i = 0; i < _terrain.Length; i++)
            {
                Console.Write($"[{_terrain[i]}]");
            }
            Console.WriteLine("\n");
        }

        private void DisplayHUD()
        {
            Console.WriteLine("--- STATUS ---");
            Console.WriteLine($"{_player.Name} | Vida: {_player.CurrentHealth}/{_player.MaxHealth} | Posi��o: {_player.Position}");
            Console.WriteLine($"{_enemy.Name} | Vida: {_enemy.CurrentHealth}/{_enemy.MaxHealth} | Posi��o: {_enemy.Position}");
            Console.WriteLine("----------------");
        }
    }
}