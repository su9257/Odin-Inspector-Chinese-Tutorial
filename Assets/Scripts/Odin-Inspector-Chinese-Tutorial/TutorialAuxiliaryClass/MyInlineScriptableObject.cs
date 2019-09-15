using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyInline_ScriptableObject", menuName = "CreatScriptableObject/MyInlineScriptableObject")]
public class MyInlineScriptableObject : ScriptableObject
{
    [ShowInInlineEditors]
    public string ShownInInlineEditor;

    [HideInInlineEditors]//在绘制的里面不显示
    public string HiddenInInlineEditor;
}
