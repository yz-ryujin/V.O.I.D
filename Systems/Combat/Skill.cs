using System;
using Void.Entities.Characters;

namespace Void.Systems.Combat
{

    public abstract class Skill
    {
        // Propriedades comuns a todas as habilidades
        public string Name { get; protected set; } // Nome da habilidade
        public string Description { get; protected set; } // Descrição da habilidade
        public int Damage { get; protected set; } // Dano causado pela habilidade
        // Depois podemos adicionar custo de mana, cooldown, etc.

        /// <summary>
        /// O construtor que as classes filhas usarão para se definir.
        /// </summary>
        
        public Skill(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Damage = damage;
        }

        // O método é abstrato (molde) para que todas as habilidades implementem sua própria lógica
        // Ele definirá o que acontece quando a habilidade é usada
        public abstract void Execute(Entity user, Entity target);
    }
}


