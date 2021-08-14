using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    public class PlayerEntity : EntityBase
    {
        [SerializeField] InputAxisData inputAxis = new InputAxisData();
        [SerializeField] InputMouseData inputMouse = new InputMouseData();
        [SerializeField] MovementData movement = new MovementData();

        protected override void EntityComponent(out IComponent[] components, out Component[] monoComponents)
        {
            components = new IComponent[]
            {
                inputAxis,
                inputMouse,
                movement,
            };

            monoComponents = new Component[]
            {
                GetComponent<Transform>(),
            };
        }
    }

}
