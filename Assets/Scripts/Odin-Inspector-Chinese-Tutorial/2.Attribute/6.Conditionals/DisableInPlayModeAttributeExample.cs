using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInPlayModeAttributeExample : MonoBehaviour
{
    [Title("Disabled in play mode")]
    [DisableInPlayMode]
    public int A;

    [DisableInPlayMode]
    public Material B;
}
