using System.Collections.Generic;
using UnityEngine;
using EntityComponentSystem.LogicSystem;
using Reflection;
using System;

namespace EntityComponentSystem
{

    public class GameEntities : MonoBehaviour
    {
        //Entities
        EntityBase[] entities;

        #region IComponents
        protected internal InputAxisData[] inputAxisDatas;
        protected internal InputMouseData[] inputMouseDatas;

        protected internal MovementData[] movementDatas;
        protected internal CollisionData[] collisionDatas;

        protected internal EnemyData[] enemyDatas;
        #endregion

        #region MonoComponents
        protected internal Transform[] transforms;

        #endregion

        #region Systems

        [SerializeField] SystemSetter systemSetter = new SystemSetter();
        SystemBase[] systems;
        #endregion

        #region Initial
        public void Initial(in EntityBase[] defaultEntities)
        {
            InitialEntities(defaultEntities);
            ComponentsInitial(entities.Length);
            SystemsInitial();
        }

        //Entities
        void InitialEntities(EntityBase[] setEntities)
        {
            entities = new EntityBase[setEntities.Length];
            for (int i = 0; i < setEntities.Length; i++)
            {
                entities[i] = setEntities[i];
                entities[i].Initial();
                entities[i].entityID = i;
            }
        }

        //Components
        void ComponentsInitial(int amount)
        {
            inputAxisDatas = new InputAxisData[amount];
            inputMouseDatas = new InputMouseData[amount];

            movementDatas = new MovementData[amount];
            collisionDatas = new CollisionData[amount];
            enemyDatas = new EnemyData[amount];

            transforms = new Transform[amount];

            for (int i = 0; i < amount; i++)
            {
                SetComponentList(entities[i], i);
                SetMonoComponentList(entities[i], i);
            }
        }
        void SetComponentList(EntityBase entity, int entityIndex)
        {
            IComponent[] components = entity.components;
            for (int i = 0; i < components.Length; i++)
            {
                switch (components[i])
                {
                    case InputAxisData inputAxisData:
                        inputAxisDatas[entityIndex] = inputAxisData;
                        break;

                    case InputMouseData inputMouseData:
                        inputMouseDatas[entityIndex] = inputMouseData;
                        break;

                    case MovementData movementData:
                        movementDatas[entityIndex] = movementData;
                        break;

                    case CollisionData collisionData:
                        collisionDatas[entityIndex] = collisionData;
                        break;

                    case EnemyData enemyData:
                        enemyDatas[entityIndex] = enemyData;
                        break;

                    default:
                        Debug.LogWarning("lost component, component name: " + components[i].GetType());
                        break;
                }
            }
        }
        void SetMonoComponentList(EntityBase entity, int entityIndex)
        {
            Component[] monoComponents = entity.monoComponents;
            for (int i = 0; i < monoComponents.Length; i++)
            {
                switch (monoComponents[i])
                {
                    case Transform transform:
                        transforms[entityIndex] = transform;
                        break;

                    //case SpriteRenderer spriteRenderer:
                        
                    //    break;

                    default:
                        Debug.LogWarning("lost component, component name: " + monoComponents[i].GetType());
                        break;
                }
            }
        }

        //Systems
        void SystemsInitial()
        {
            systems = systemSetter.CreateSystems();

            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Initial(entities, this);
            }
        }
        #endregion

        //Update
        public void EntitiesUpdate(float deltaTime)
        {
            foreach (var system in systems)
            {
                system.Update(deltaTime);
            }
        }


    }

}
