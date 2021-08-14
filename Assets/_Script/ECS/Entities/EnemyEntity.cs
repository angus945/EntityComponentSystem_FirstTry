using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    public class EnemyEntity : EntityBase
    {

        [SerializeField] EnemyData enemyData = new EnemyData();
        [SerializeField] MovementData movementData = new MovementData();
        [SerializeField] CollisionData collisionDetect = new CollisionData(10);

        protected override void EntityComponent(out IComponent[] components, out Component[] monoCompoments)
        {
            components = new IComponent[]
            {
                enemyData,
                movementData,
                collisionDetect,
            };
            monoCompoments = new Component[]
            {
                GetComponent<Transform>(),
            };
        }
    }

}
