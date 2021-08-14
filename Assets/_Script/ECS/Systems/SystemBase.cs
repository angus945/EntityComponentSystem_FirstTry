using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    public abstract class SystemBase
    {
        List<int> containIndexs = new List<int>();
        protected GameEntities gameEntities;

        protected internal void Initial(in EntityBase[] entities, GameEntities gameEntities)
        {
            this.gameEntities = gameEntities;

            SetContain(entities);
        }
        protected internal void SetContain(in EntityBase[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                if (ContainComponent(entities[i]))
                {
                    containIndexs.Add(i);
                }
            }
        }
        protected internal void Update(float deltaTime)
        {
            for (int i = 0; i < containIndexs.Count; i++)
            {
                int componentIndex = containIndexs[i];
                Foreach(componentIndex, deltaTime);
            }
        }

        /// <summary>
        /// return system need components is contain on entity 
        /// entity.ContainComponent<T>();
        /// entity.ContainMonoComponent<T>();
        /// </summary>
        protected abstract bool ContainComponent(EntityBase entity);

        /// <summary>
        /// update method of singel entity(component)
        /// gameEntities.components[index]...
        /// </summary>
        protected abstract void Foreach(int componentIndex, float delta);

        public void Debug_PrintContain()
        {
            string list = "";
            foreach (var index in containIndexs)
            {
                list += index + ", ";
            }
            Debug.Log(list);
        }
    }
}

