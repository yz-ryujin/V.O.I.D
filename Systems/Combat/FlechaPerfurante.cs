using System;
using Void.Entities.Characters;

namespace Void.Systems.Combat
{
    public class FlechaPerfurante : Skill
    {

        public FlechaPerfurante() 
            : base("Flecha Perfurante", "Um disparo poderoso que atravessa armaduras.", 40)
        {
        }

        public override void Execute(Entity caster, Entity target)
        {
            Console.WriteLine($"> {caster.Name} prepara um disparo especial!");

            int distanceToTarget = Math.Abs(caster.Position - target.Position);

            if (distanceToTarget <= caster.AttackRange)
            {
                Console.WriteLine($"> A flecha perfurante atinge {target.Name} com imensa força!");
                target.CurrentHealth -= this.Damage;
                Console.WriteLine($"> {target.Name} sofreu {this.Damage} de dano massivo!");
            }
            else
            {
                Console.WriteLine("> O alvo está muito distante para um tiro preciso!");
            }
        }
    }
}