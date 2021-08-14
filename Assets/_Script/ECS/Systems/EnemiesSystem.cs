using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    public class EnemiesSystem : SystemBase
    {
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<EnemyData>() && entity.ContainComponent<CollisionData>();
        }

        protected override void Foreach(int componentIndex, float delta)
        {
            ref EnemyData enemy = ref gameEntities.enemyDatas[componentIndex];
            CollisionData collision = gameEntities.collisionDatas[componentIndex];

            enemy.lifeTime -= delta;

            if (collision.collideAmount > 0) Debug.Break();
        }

    }
}
