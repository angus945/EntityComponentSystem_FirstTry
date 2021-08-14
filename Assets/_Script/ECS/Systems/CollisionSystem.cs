using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    public class CollisionSystem : SystemBase
    {
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<CollisionData>() && entity.ContainMonoComponent<Transform>();
        }

        Collider2D[] targets = new Collider2D[50];
        protected override void Foreach(int componentIndex, float delta)
        {
            ref CollisionData collision = ref gameEntities.collisionDatas[componentIndex];
            Transform transform = gameEntities.transforms[componentIndex];

            collision.collideAmount = Physics2D.OverlapCircleNonAlloc(transform.position, collision.radius, targets, collision.collideLayer);
            for (int i = 0; i < collision.collideAmount; i++)
            {
                collision.targetEntities[i] = targets[i].GetComponent<EntityBase>().entityID;
            }
        }
    }
}

