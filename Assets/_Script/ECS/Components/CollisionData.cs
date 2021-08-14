using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    [System.Serializable]
    public struct CollisionData : IComponent
    {
        public float radius;
        public LayerMask collideLayer;

        public int[] targetEntities;
        public int collideAmount;

        public CollisionData(int targetArrayLength) : this()
        {
            targetEntities = new int[targetArrayLength];
        }
    }

}
