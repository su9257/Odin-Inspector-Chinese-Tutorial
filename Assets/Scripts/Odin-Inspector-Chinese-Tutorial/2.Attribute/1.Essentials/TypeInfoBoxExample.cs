using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class TypeInfoBoxExample : MonoBehaviour
{
    public MyType MyObject = new MyType();

    [InfoBox("双击此此段的value值，可在inspecter中查看对应ScriptableObject信息")]
    public MyScripty Scripty = null;
    public void Awake()
    {
        Scripty = ExampleHelper.GetScriptableObject<MyScripty>();
    }


    [Serializable]
    [TypeInfoBox("TypeInfoBox特性可以放在类型定义上，并将导致在属性的顶端处绘制一个InfoBox。")]
    public class MyType
    {
        public int Value;
    }
}

