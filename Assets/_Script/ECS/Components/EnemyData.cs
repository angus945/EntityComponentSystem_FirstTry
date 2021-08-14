using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    [System.Serializable]
    public struct EnemyData : IComponent
    {
        public float lifeTime;
        public Vector2 spawnRange;
    }
}

