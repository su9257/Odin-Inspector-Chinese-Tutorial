using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInPlayModeAttributeExample : MonoBehaviour
{
    [Title("运行模式下禁用属性")]
    [DisableInPlayMode]
    public int A;

    [DisableInPlayMode]
    public Material B;
}
