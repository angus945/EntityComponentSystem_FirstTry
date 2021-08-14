using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    public class EntityInstantiater : MonoBehaviour
    {
        [SerializeField] PlayerEntity playerEntityPrefab = null;
        [SerializeField] EnemyEntity enemyEntityPrefab = null;

        public EntityBase[] InstantiateEntities()
        {
            EntityBase[] entities = new EntityBase[30];

            entities[0] = Instantiate(playerEntityPrefab);

            for (int i = 1; i < entities.Length; i++)
            {
                entities[i] = Instantiate(enemyEntityPrefab);
            }

            return entities;
        }
    }

}
