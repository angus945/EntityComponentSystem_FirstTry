using EntityComponentSystem;
using EntityComponentSystem.LogicSystem;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomPropertyDrawer(typeof(SystemSetter), true)]
public class SystemSetterEditor : PropertyDrawer
{

    ReorderableList list;

    public SystemSetterEditor() : base()
    {


    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty nameSpace = property.FindPropertyRelative("nameSpace");
        SerializedProperty nameList = property.FindPropertyRelative("systemNames");

        EditorGUI.PropertyField(position, nameSpace, new GUIContent("nameSpace"), true);

        position.y += 20;
        ReorderableList list = GetReorderbleList(property);
        list.DoList(position);


    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return GetReorderbleList(property).GetHeight() + 20;
    }


    ReorderableList GetReorderbleList(SerializedProperty property)
    {
        if (list != null) return list;

        SerializedProperty nameSpace = property.FindPropertyRelative("nameSpace");
        SerializedProperty nameList = property.FindPropertyRelative("systemNames");

        list = new ReorderableList(property.serializedObject, nameList, true, true, true, true);
        list.drawHeaderCallback += (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Systemlist, Execute with order");
        };
        list.drawElementCallback += (Rect rect, int index, bool isA, bool isF) =>
        {
            SerializedProperty element = nameList.GetArrayElementAtIndex(index);
            if (TypeInstancer.CheckHasFound<SystemBase>(nameSpace.stringValue, element.stringValue))
            {
                if (CheckHasRepeat(nameList, index)) GUI.backgroundColor = Color.yellow;

                EditorGUI.PropertyField(rect, element, new GUIContent( index + ", " + element.stringValue));  
            }
            else
            {
                GUI.backgroundColor = Color.red;
                EditorGUI.PropertyField(rect, element, new GUIContent("System not found"));
            }

            GUI.backgroundColor = Color.white;

        };
        list.elementHeight = 20;


        return list;
    }
    bool CheckHasRepeat(SerializedProperty list, int index)
    {
        string current = list.GetArrayElementAtIndex(index).stringValue;

        for (int i = 0; i < list.arraySize; i++)
        {
            if (i == index) continue;

            if (current == list.GetArrayElementAtIndex(i).stringValue) return true;
        }
        return false;
    }


}
