using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    public class MovementSystem : SystemBase
    {
        //MovementData, Transform
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<MovementData>() && entity.ContainMonoComponent<Transform>();
        }
        protected override void Foreach(int componentIndex, float delta)
        {
            MovementData movementData = gameEntities.movementDatas[componentIndex];
            ref Transform transform = ref gameEntities.transforms[componentIndex];

            transform.position += movementData.moveDirection * movementData.speed * delta;
        }
    }

}
