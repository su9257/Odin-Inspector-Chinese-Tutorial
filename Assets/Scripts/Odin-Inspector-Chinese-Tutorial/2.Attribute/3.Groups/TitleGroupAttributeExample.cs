using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGroupAttributeExample : MonoBehaviour
{
    [TitleGroup("Ints")]
    public int SomeInt1;

    [TitleGroup("$SomeString1", "Optional subtitle")]
    public string SomeString1;


    [TitleGroup("Vectors", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: true)]

    [TitleGroup("Vectors", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public Vector2 SomeVector1;

    [TitleGroup("Ints", "Optional subtitle", alignment: TitleAlignments.Split)]
    public int SomeInt2;

    [TitleGroup("$SomeString1", "Optional subtitle")]
    public string SomeString2;

    [TitleGroup("Vectors")]
    public Vector2 SomeVector2 { get; set; }

    [TitleGroup("Ints/Buttons", indent: false)]
    private void IntButton() { }

    [TitleGroup("$SomeString1/Buttons", indent: false)]
    private void StringButton() { }

    [TitleGroup("Vectors")]
    private void VectorButton() { }

    [BoxGroup("Titles", ShowLabel = false)]
    [TitleGroup("Titles/First Title")]
    public int A;

    [BoxGroup("Titles/Boxed")]
    [TitleGroup("Titles/Boxed/Second Title")]
    public int B;

    [TitleGroup("Titles/Boxed/Second Title")]
    public int C;

    [TitleGroup("Titles/Horizontal Buttons")]
    [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
    public void FirstButton() { }

    [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
    public void SecondButton() { }

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
