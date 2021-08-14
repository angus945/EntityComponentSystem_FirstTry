using EntityComponentSystem.LogicSystem;
using System.Collections.Generic;

namespace EntityComponentSystem
{
    [System.Serializable]
    public struct SystemSetter
    {
        public string nameSpace;
        public string[] systemNames;

        public SystemBase[] CreateSystems()
        {
            List<SystemBase> systems = new List<SystemBase>();

            for (int i = 0; i < systemNames.Length; i++)
            {
                if (TypeInstancer.TryGenerateObject<SystemBase>(nameSpace, systemNames[i], out SystemBase system))
                {
                    systems.Add(system);
                }
            }

            return systems.ToArray();
        }
        public bool CheckHasSystem(int nameIndex)
        {
            return TypeInstancer.CheckHasFound<SystemBase>(nameSpace, systemNames[nameIndex]);
        }
    }
}
