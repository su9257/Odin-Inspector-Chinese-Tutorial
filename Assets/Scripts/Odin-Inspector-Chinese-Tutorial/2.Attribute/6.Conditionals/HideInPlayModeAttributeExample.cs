using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInPlayModeAttributeExample : MonoBehaviour
{
    [Title("Hidden in play mode")]
    [HideInPlayMode]
    public int A;

    [HideInPlayMode]
    public int B;
}
