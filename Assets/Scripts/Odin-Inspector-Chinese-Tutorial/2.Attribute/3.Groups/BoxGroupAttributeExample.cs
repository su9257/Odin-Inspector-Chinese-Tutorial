using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGroupAttributeExample : MonoBehaviour
{

    // Box with a title.
    [BoxGroup("Some Title")]
    public string A;

    [BoxGroup("Some Title")]
    public string B;

    // Box with a centered title.
    [BoxGroup("Centered Title", centerLabel: true)]
    public string C;

    [BoxGroup("Centered Title")]
    public string D;

    // Box with a title received from a field.
    [BoxGroup("$G")]
    public string E = "Dynamic box title 2";

    [BoxGroup("$G")]
    public string F;

    // No title
    [BoxGroup]
    public string G;

    [BoxGroup]
    public string H;

    // A named box group without a title.
    [BoxGroup("NoTitle", false)]
    public string I;

    [BoxGroup("NoTitle")]
    public string J;

    [BoxGroup("A Struct In A Box"), HideLabel]
    public SomeStruct BoxedStruct;

    public SomeStruct DefaultStruct;

    [Serializable]
    public struct SomeStruct
    {
        public int One;
        public int Two;
        public int Three;
    }


    [BoxGroup("Titles", ShowLabel = false)]
    [TitleGroup("Titles/First Title")]
    public int A1;

    [BoxGroup("Titles/Boxed")]
    [TitleGroup("Titles/Boxed/Second Title")]
    public int B1;
    [TitleGroup("Titles/Boxed/Second Title")]
    public int C1;

    [TitleGroup("Titles/Horizontal Buttons")]
    [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
    public void FirstButton() { }

    [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
    public void SecondButton() { }


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
}
