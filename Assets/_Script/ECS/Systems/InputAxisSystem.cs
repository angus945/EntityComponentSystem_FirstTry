using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    //InputData
    public class InputAxisSystem : SystemBase
    {
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<InputAxisData>();
        }

        protected override void Foreach(int index, float delta)
        {
            ref InputAxisData inputAxisData = ref gameEntities.inputAxisDatas[index];

            inputAxisData.horizontal = Input.GetAxisRaw(InputVariable.inputHorizontal);
            inputAxisData.vertical = Input.GetAxisRaw(InputVariable.inputVertical);
        }
    }

}
