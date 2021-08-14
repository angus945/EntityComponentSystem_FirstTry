using System;
using UnityEngine;

public class TypeInstancer
{
    public static bool TryGenerateObject<T>(string nameSpace, string typeName, out T typeObject)
    {
        Type type = Type.GetType(nameSpace + "." + typeName);

        object obj = Activator.CreateInstance(type);

        if (type.IsSubclassOf(typeof(T)))
        {
            typeObject = (T)Convert.ChangeType(obj, type);
            return true;
        }

        typeObject = default(T);
        return false;
    }
    public static bool CheckHasFound<T>(string nameSpace, string typeName)
    {
        Type type = Type.GetType(nameSpace + "." + typeName);

        return type != null && type.IsSubclassOf(typeof(T));
    }
}
