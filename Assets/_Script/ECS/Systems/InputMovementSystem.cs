using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    //InputData
    //Transform
    public class InputMovementSystem : SystemBase
    {
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<InputAxisData>() && entity.ContainComponent<MovementData>();
        }
        protected override void Foreach(int componentIndex, float delta)
        {
            InputAxisData inputAxisData = gameEntities.inputAxisDatas[componentIndex];
            ref MovementData movementData = ref gameEntities.movementDatas[componentIndex];

            float horizontal = inputAxisData.horizontal;
            float vertical = inputAxisData.vertical;

            Vector3 direction = new Vector3(horizontal, vertical).normalized;
            movementData.moveDirection = direction;
        }
    }

}
