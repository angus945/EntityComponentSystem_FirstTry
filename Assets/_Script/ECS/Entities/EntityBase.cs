using System.Collections.Generic;
using UnityEngine;


namespace EntityComponentSystem
{
    public abstract class EntityBase : MonoBehaviour
    {
        [HideInInspector] public int entityID;

        [HideInInspector] public IComponent[] components = null;
        [HideInInspector] public Component[] monoComponents = null;

        public bool ContainComponent<T>() where T : IComponent
        {
            foreach (var component in components)
            {
                if (component is T) return true;
            }

            return false;
        }
        public bool ContainMonoComponent<T>() where T : Component
        {
            foreach (var component in monoComponents)
            {
                if (component is T) return true;
            }

            return false;
        }

        public void Initial()
        {
            EntityComponent(out IComponent[] components, out Component[] monoComponents);
            this.components = components;
            this.monoComponents = monoComponents;
        }

        /// <summary>
        /// return out entity components
        /// </summary>
        protected abstract void EntityComponent(out IComponent[] components, out Component[] monoCompoments);
    }
}