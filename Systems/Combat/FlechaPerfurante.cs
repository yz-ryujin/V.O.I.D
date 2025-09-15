using System;
using Void.Entities.Characters;

namespace Void.Systems.Combat
{
    // A classe herda de Skill, recebendo todos as propriedades e m�todos
    public class FlechaPerfurante : Skill
    {

        // O construtor define os valores para esta habilidade
        // A sintaxe ": base(...)" passa os valores para o construtor da classe Skill.
        public FlechaPerfurante() 
            : base("Flecha Perfurante", "Um disparo poderoso que atravessa armaduras.", 40)
        {
        }

        // Implementa o m�todo "Execute" da classe Skill. O override � usado para sobrescrever a l�gica do m�todo.
        public override void Execute(Entity caster, Entity target)
        {
            Console.WriteLine($"> {caster.Name} prepara um disparo especial!");

            int distanceToTarget = Math.Abs(caster.Position - target.Position);

            // A habilidade usa o alcance do ataque b�sico do personagem
            if (distanceToTarget <= caster.AttackRange)
            {
                Console.WriteLine($"> A flecha perfurante atinge {target.Name} com imensa for�a!");
                target.CurrentHealth -= this.Damage; // Usa o dano definido no construtor (40)
                Console.WriteLine($"> {target.Name} sofreu {this.Damage} de dano massivo!");
            }
            else
            {
                Console.WriteLine("> O alvo est� muito distante para um tiro preciso!");
            }
        }
    }
}