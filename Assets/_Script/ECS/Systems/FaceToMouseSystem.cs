using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    //InputMouse
    public class FaceToMouseSystem : SystemBase
    {
        //InputMouseData
        //Transform
        //MovementData
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<InputMouseData>() && entity.ContainMonoComponent<Transform>() && entity.ContainComponent<MovementData>();
        }

        protected override void Foreach(int componentIndex, float delta)
        {
            InputMouseData inputMouseData = gameEntities.inputMouseDatas[componentIndex];
            Transform transform = gameEntities.transforms[componentIndex];
            ref MovementData movementData = ref gameEntities.movementDatas[componentIndex];

            Vector3 mousePos = inputMouseData.mousePosition;
            Vector3 position = transform.position;

            movementData.faceDirection = (mousePos - position).normalized;
        }
    }

}
