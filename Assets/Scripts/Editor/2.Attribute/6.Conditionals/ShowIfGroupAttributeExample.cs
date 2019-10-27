using Sirenix.OdinInspector;
using UnityEngine;

public class ShowIfGroupAttributeExample : MonoBehaviour
{
    public bool Toggle = true;

    [ShowIfGroup("Toggle")]
    [BoxGroup("Toggle/Shown Box")]
    public int A, B;

    [BoxGroup("Box")]
    public InfoMessageType EnumField = InfoMessageType.Info;

    [BoxGroup("Box")]
    [ShowIfGroup("Box/Toggle")]
    public Vector3 X, Y;

    //与常规if属性一样，ShowIfGroup也支持指定值。
    //您还可以将多个ShowIfGroup属性链接在一起，以实现更复杂的行为。
    [ShowIfGroup("Box/Toggle/EnumField", Value = InfoMessageType.Info)]
    [BoxGroup("Box/Toggle/EnumField/Border", ShowLabel = false)]
    public string Name;

    [BoxGroup("Box/Toggle/EnumField/Border")]
    public Vector3 Vector;

    // ShowIfGroup将默认使用组的名称，
    //但是您也可以使用MemberName属性来覆盖它。
    [ShowIfGroup("RectGroup", MemberName = "Toggle")]
    public Rect Rect;
}
