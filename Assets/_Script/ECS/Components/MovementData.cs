using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    [System.Serializable]
    public struct MovementData : IComponent
    {
        public float speed;
        public Vector3 moveDirection;
        public Vector3 faceDirection;

        public MovementData(float speed) : this()
        {
            this.speed = speed;
        }
    }
}

