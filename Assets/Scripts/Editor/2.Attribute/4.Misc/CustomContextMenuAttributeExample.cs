using Sirenix.OdinInspector;
using UnityEngine;

public class CustomContextMenuAttributeExample : MonoBehaviour
{
    [InfoBox("右键属性可在菜单中出发指定的函数.")]
    [CustomContextMenu("Say Hello/菜鸟海澜", "SayHelloFunction")]
    public int MyProperty;

    private void SayHelloFunction()
    {
        Debug.Log("Hello 菜鸟海澜");
    }
}