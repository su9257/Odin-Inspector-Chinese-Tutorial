using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfGroupAttributeExample : MonoBehaviour
{
    public bool Toggle = true;

    [HideIfGroup("Toggle")]
    [BoxGroup("Toggle/Shown Box")]
    public int A, B;

    [BoxGroup("Box")]
    public InfoMessageType EnumField = InfoMessageType.Info;

    [BoxGroup("Box")]
    [HideIfGroup("Box/Toggle")]
    public Vector3 X, Y;

    // Like the regular If-attributes, HideIfGroup also supports specifying values.
    // You can also chain multiple HideIfGroup attributes together for more complex behaviour.
    [HideIfGroup("Box/Toggle/EnumField", Value = InfoMessageType.Info)]
    [BoxGroup("Box/Toggle/EnumField/Border", ShowLabel = false)]
    public string Name;

    [BoxGroup("Box/Toggle/EnumField/Border")]
    public Vector3 Vector;

    // HideIfGroup will by default use the name of the group,
    // but you can also use the MemberName property to override this.
    [ShowIfGroup("RectGroup", MemberName = "Toggle")]
    public Rect Rect;
}
