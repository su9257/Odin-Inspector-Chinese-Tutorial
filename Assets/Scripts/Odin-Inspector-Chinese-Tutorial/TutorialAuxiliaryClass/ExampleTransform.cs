using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 您还可以直接在类定义本身上使用InlineEditor属性。
//[InlineEditor]
[CreateAssetMenu(fileName = "ExampleTransform_ScriptableObject", menuName = "CreatScriptableObject/ExampleTransform")]
public class ExampleTransform : ScriptableObject
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale = Vector3.one;
}
