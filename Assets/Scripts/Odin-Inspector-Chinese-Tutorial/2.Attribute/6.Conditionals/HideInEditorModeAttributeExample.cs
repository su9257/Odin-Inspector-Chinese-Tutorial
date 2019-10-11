using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInEditorModeAttributeExample : MonoBehaviour
{
    [Title("Hidden in editor mode")]//在editor下隐藏属性，运行时显示属性
    [HideInEditorMode]
    public int C;

    [HideInEditorMode]
    public int D;
}
