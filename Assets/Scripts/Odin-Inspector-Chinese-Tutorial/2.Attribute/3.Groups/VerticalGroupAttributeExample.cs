using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGroupAttributeExample : MonoBehaviour
{
    [HorizontalGroup("Split")]
    [VerticalGroup("Split/Left")]
    public InfoMessageType First;

    [VerticalGroup("Split/Left")]
    public InfoMessageType Second;

    [HideLabel]
    [VerticalGroup("Split/Right")]
    public int A;

    [HideLabel]
    [VerticalGroup("Split/Right")]
    public int B;

    [TitleGroup("Multiple Stacked Boxes")]
    [HorizontalGroup("Multiple Stacked Boxes/Split")]
    [VerticalGroup("Multiple Stacked Boxes/Split/Left")]
    [BoxGroup("Multiple Stacked Boxes/Split/Left/Box A")]
    public int BoxA1;

    [BoxGroup("Multiple Stacked Boxes/Split/Left/Box B")]
    public int BoxB1;

    [VerticalGroup("Multiple Stacked Boxes/Split/Right")]
    [BoxGroup("Multiple Stacked Boxes/Split/Right/Box C")]
    public int BoxC1, BoxD1, BoxE1;
}
