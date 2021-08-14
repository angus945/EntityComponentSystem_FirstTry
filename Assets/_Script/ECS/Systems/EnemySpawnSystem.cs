using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem.LogicSystem
{
    public class EnemySpawnSystem : SystemBase
    {
        protected override bool ContainComponent(EntityBase entity)
        {
            return entity.ContainComponent<EnemyData>() && entity.ContainComponent<MovementData>() && entity.ContainMonoComponent<Transform>();
        }

        protected override void Foreach(int componentIndex, float delta)
        {
            ref EnemyData enemyData = ref gameEntities.enemyDatas[componentIndex];
            ref MovementData movementData = ref gameEntities.movementDatas[componentIndex];
            ref Transform transform = ref gameEntities.transforms[componentIndex];

            if (enemyData.lifeTime <= 0)
            {
                transform.position = RandomPosition(enemyData.spawnRange);

                enemyData.lifeTime = Random.Range(5, 10);
                movementData.speed = Random.Range(5, 10);

                Vector3 randomDir = Random.insideUnitCircle;
                randomDir.x = (transform.position.x > 0) ? -Mathf.Abs(randomDir.x) : Mathf.Abs(randomDir.x);
                randomDir.y = (transform.position.y > 0) ? -Mathf.Abs(randomDir.y) : Mathf.Abs(randomDir.y);
                movementData.moveDirection = randomDir;
            }
        }

        Vector3 RandomPosition(Vector3 range)
        {
            Vector3 randomPos = new Vector3(Random.Range(-1.1f, 1.1f) * range.x, Random.Range(-1.1f, 1.1f) * range.y);
            if (randomPos.x < range.x) randomPos.y = range.y * (Random.value > 0.5 ? -1 : 1);

            return randomPos;
        }

    }

}

