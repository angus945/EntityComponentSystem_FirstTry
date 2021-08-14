using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    public class InputMouseSystem : SystemBase
    {
        //InputMouseData
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<InputMouseData>();
        }

        protected override void Foreach(int componentIndex, float delta)
        {
            ref InputMouseData mouseData = ref gameEntities.inputMouseDatas[componentIndex];

            mouseData.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                if (mouseData.leftMouseState == 0) mouseData.leftMouseState = 1;
                else mouseData.leftMouseState = 2;
            }
            else mouseData.leftMouseState = 0;
        }
    }

}
