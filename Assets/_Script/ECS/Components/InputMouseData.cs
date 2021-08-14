using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityComponentSystem
{
    [System.Serializable]
    public struct InputMouseData : IComponent
    {
        public Vector2 mousePosition;
        public int leftMouseState;
        public int rightMouseState;
    }

}

