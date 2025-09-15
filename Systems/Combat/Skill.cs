using System;
using Void.Entities.Characters;

namespace Void.Systems.Combat
{

    public abstract class Skill
    {
        // Propriedades comuns a todas as habilidades
        public string Name { get; protected set; } // Nome da habilidade
        public string Description { get; protected set; } // Descri��o da habilidade
        public int Damage { get; protected set; } // Dano causado pela habilidade
        // Depois podemos adicionar custo de mana, cooldown, etc.

        /// <summary>
        /// O construtor que as classes filhas usar�o para se definir.
        /// </summary>
        
        public Skill(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Damage = damage;
        }

        // O m�todo � abstrato (molde) para que todas as habilidades implementem sua pr�pria l�gica
        // Ele definir� o que acontece quando a habilidade � usada
        public abstract void Execute(Entity user, Entity target);
    }
}


