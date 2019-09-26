using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInEditorModeAttributeExample : MonoBehaviour
{
    [Title("Disabled in edit mode")]
    [DisableInEditorMode]
    public GameObject A;

    [DisableInEditorMode]
    public Material B;
}
