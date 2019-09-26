using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInEditorModeAttributeExample : MonoBehaviour
{
    [Title("Hidden in editor mode")]
    [HideInEditorMode]
    public int C;

    [HideInEditorMode]
    public int D;
}
