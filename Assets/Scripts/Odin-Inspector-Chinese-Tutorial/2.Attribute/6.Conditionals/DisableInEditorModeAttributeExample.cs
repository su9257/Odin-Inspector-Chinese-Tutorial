using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInEditorModeAttributeExample : MonoBehaviour
{
    [Title("Disabled in edit mode")]//在Editor模式下灰态对应的属性或字段
    [DisableInEditorMode]
    public GameObject A;

    [DisableInEditorMode]
    public Material B;
}
