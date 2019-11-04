using Sirenix.OdinInspector;
using UnityEngine;

public class ShowIfAttributeExample : MonoBehaviour
{
    public UnityEngine.Object SomeObject;

    [EnumToggleButtons]
    public InfoMessageType SomeEnum;

    public bool IsToggled;

    [ShowIf("SomeEnum", InfoMessageType.Info)]
    public Vector3 Info;

    [ShowIf("SomeEnum", InfoMessageType.Warning)]
    public Vector2 Warning;

    [ShowIf("SomeEnum", InfoMessageType.Error)]
    public Vector3 Error;

    [ShowIf("IsToggled")]
    public Vector2 VisibleWhenToggled;

    [ShowIf("@this.IsToggled && this.SomeObject != null || this.SomeEnum == InfoMessageType.Error")]
    public Vector3 HideWhenNull;
}
