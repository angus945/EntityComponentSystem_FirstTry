using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarialbeInitializer : MonoBehaviour
{
    [SerializeField] InputVariable inputVariable = null;

    void Awake()
    {
        inputVariable.Initial();
    }
}
