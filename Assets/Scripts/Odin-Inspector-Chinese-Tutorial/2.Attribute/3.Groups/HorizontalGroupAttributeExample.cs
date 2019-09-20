using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGroupAttributeExample : MonoBehaviour
{
    [HorizontalGroup]
    public int A;

    [HideLabel, LabelWidth(150)]
    [HorizontalGroup(150)]
    public LayerMask B;

    [HorizontalGroup("Group 1", LabelWidth = 20)]
    public int C;

    [HorizontalGroup("Group 1")]
    public int D;

    [HorizontalGroup("Group 1")]
    public int E;

    [HorizontalGroup("Split", 0.5f, LabelWidth = 20)]
    [BoxGroup("Split/Left")]
    public int L;

    [BoxGroup("Split/Right")]
    public int M;

    [BoxGroup("Split/Left")]
    public int N;

    [BoxGroup("Split/Right")]
    public int O;

    [HorizontalGroup("MyButton", MarginLeft = 0.25f, MarginRight = 0.25f)]
    public void SomeButton()
    {
        // ...
    }

    [Button(ButtonSizes.Large)]
    [FoldoutGroup("Buttons in Boxes")]
    [HorizontalGroup("Buttons in Boxes/Horizontal")]
    [BoxGroup("Buttons in Boxes/Horizontal/One")]
    public void Button1() { }

    [Button(ButtonSizes.Large)]
    [BoxGroup("Buttons in Boxes/Horizontal/Two")]
    public void Button2() { }

    [Button]
    [HorizontalGroup("Buttons in Boxes/Horizontal", Width = 60)]
    [BoxGroup("Buttons in Boxes/Horizontal/Double")]
    public void Accept() { }

    [Button]
    [BoxGroup("Buttons in Boxes/Horizontal/Double")]
    public void Cancel() { }

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
    public int BoxA1;

    [BoxGroup("Multiple Stacked Boxes/Split/Left/Box B")]
    public int BoxB1;

    [VerticalGroup("Multiple Stacked Boxes/Split/Right")]
    [BoxGroup("Multiple Stacked Boxes/Split/Right/Box C")]
    public int BoxC1, BoxD1, BoxE1;
}
