using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Global InputVariable", menuName = "GlobalVariable/Input")]
public class InputVariable : ScriptableObject
{
    static InputVariable instance;

    [SerializeField] string _inputHorizontal = "Horizontal";
    [SerializeField] string _inputVertical = "Vertical";

    public static string inputHorizontal { get => instance._inputHorizontal; }
    public static string inputVertical { get => instance._inputVertical; }

    public void Initial()
    {
        instance = this;
    }


}
