
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
                    // Implementa��o do mecanismo de a��o do jogador
                    HandlePlayerAction();
                }
                else
                {
                    _enemy.PerformAction(_player);
                }

                _isPlayerTurn = !_isPlayerTurn; // Alterna o turno

                if(_enemy.IsAlive)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            }

            // Exibe o resultado da batalha
            DisplayBattleResult();
        }

        private void HandlePlayerAction()
        {
            Console.WriteLine("\nEscolha sua a��o:");
            Console.WriteLine("1. Andar para a Esquera (A)");
            Console.WriteLine("2. Andar para a Direita (D)");
            Console.WriteLine("3. Atacar (W)");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            switch (char.ToUpper(keyInfo.KeyChar))
            {
                case 'A':
                case'1':
                if(_player.Position > 0)
                    {
                        _player.Position--;
                        Console.WriteLine($"{_player.Name} se move para a esquerda.");
                    }
                    else
                    {
                        Console.WriteLine($"{_player.Name} est� no limite do campo e n�o pode mais recuar.");
                    }
                        break;
                case 'D':
                case'2':
                if(_player.Position < _terrain.Length - 1)
                    {
                        _player.Position++;
                        Console.WriteLine($"{_player.Name} se move para a direita.");
                    }
                    else
                    {
                        Console.WriteLine($"{_player.Name} est� no limite do campo e n�o pode mais avan�ar.");
                    }
                        break;
                case 'W':
                case'3':
                    int distanceToEnemy = Math.Abs(_player.Position - _enemy.Position);
                    if (distanceToEnemy <= _player.AttackRange)
                    {
                        Console.WriteLine($"Voc� ataca ferozmente {_enemy.Name}!");
                        _enemy.CurrentHealth -= _player.AttackDamage;
                        Console.WriteLine($"O inimigo sofreu {_player.AttackDamage} de dano.");
                    }
                    else
                    {
                       Console.WriteLine("Inimigo fora de alcance! Voc� n�o pode atac�-lo.");
                    }
                        break;
                default:
                Console.WriteLine("A��o inv�lida! Voc� hesitou e perdeu seu turno.");
                break;
            }

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

        

        private void DisplayBattleResult()
        {
            Console.Clear();
            if (_player.IsAlive)
            {
                Console.WriteLine($"******************** \n VIT�RIA! \n ******************** ");
                Console.WriteLine($"Voc� derrotou {_enemy.Name}. ");
            }
            else
            {
                Console.WriteLine($"******************** \n DERROTA! \n ******************** ");
                Console.WriteLine($"Voc� foi consumido pelo Vazio. ");
            }
        }
    }
}