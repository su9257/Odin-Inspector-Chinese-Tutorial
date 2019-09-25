using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomContextMenuAttributeExample : MonoBehaviour
{

    [InfoBox("右键属性可在菜单中出发指定的函数.")]
    [CustomContextMenu("Say Hello/菜鸟海澜", "SayHello")]
    public int MyProperty;

    private void SayHello()
    {
        Debug.Log("Hello 菜鸟海澜");
    }

}
