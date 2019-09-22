using Sirenix.OdinInspector;
using UnityEngine;

public class VerticalGroupAttributeExample : MonoBehaviour
{
    [HorizontalGroup("Split")]
    [VerticalGroup("Split/Left")]
    public InfoMessageType First;

    [VerticalGroup("Split/Left")]
    public InfoMessageType Second;

    [VerticalGroup("Split/Right")]
    public int A;

    [VerticalGroup("Split/Right")]
    public int B;

    [TitleGroup("Multiple Stacked Boxes")]
    [HorizontalGroup("Multiple Stacked Boxes/Split")]
    [VerticalGroup("Multiple Stacked Boxes/Split/Left")]
    [BoxGroup("Multiple Stacked Boxes/Split/Left/Box A")]
    public int BoxA;

    [BoxGroup("Multiple Stacked Boxes/Split/Left/Box B")]
    public int BoxB;

    [VerticalGroup("Multiple Stacked Boxes/Split/Right")]
    [BoxGroup("Multiple Stacked Boxes/Split/Right/Box C")]
    public int BoxC, BoxD, BoxE;
}