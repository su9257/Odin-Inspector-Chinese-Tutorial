using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfAttributeExample : MonoBehaviour
{
    public UnityEngine.Object SomeObject;

    [EnumToggleButtons]
    public InfoMessageType SomeEnum;

    public bool IsToggled;

    [HideIf("SomeEnum", InfoMessageType.Info)]
    public Vector3 Info;

    [HideIf("IsToggled")]
    public Vector3 HiddenWhenToggled;

    [HideIf("SomeObject")]
    public Vector3 ShowWhenNull;

    [HideIf("@this.IsToggled && this.SomeObject != null")]
    public int HideWithExpression;
}
