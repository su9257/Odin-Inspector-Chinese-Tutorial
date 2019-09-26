using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfAttributeExample : MonoBehaviour
{
    public UnityEngine.Object SomeObject;

    [EnumToggleButtons]
    public InfoMessageType SomeEnum;

    public bool IsToggled;

    [DisableIf("SomeEnum", InfoMessageType.Info)]
    public Vector2 Info;

    [DisableIf("SomeEnum", InfoMessageType.Error)]
    public Vector2 Error;

    [DisableIf("SomeEnum", InfoMessageType.Warning)]
    public Vector2 Warning;

    [DisableIf("IsToggled")]
    public int DisableIfToggled;

    [DisableIf("SomeObject")]
    public Vector3 EnabledWhenNull;

    [DisableIf("@this.IsToggled && this.SomeObject != null || this.SomeEnum == InfoMessageType.Error")]
    public int DisableWithExpression;
}
