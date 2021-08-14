using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    [System.Serializable]
    public struct InputAxisData : IComponent
    {
        public float horizontal;
        public float vertical;

    }
}

