using Sirenix.OdinInspector;
using UnityEngine;

public class TitleGroupAttributeExample : MonoBehaviour
{
    [TitleGroup("Ints")]
    public int SomeInt1;
    [TitleGroup("Ints", "Optional subtitle")]
    public int SomeInt2;

    [TitleGroup("TitleAlignments_Left", "可选副标题", alignment: TitleAlignments.Left)]
    public string titleLeft = "";
    [TitleGroup("TitleAlignments_Centered", "可选副标题", alignment: TitleAlignments.Centered)]
    public string titleCentered = "";
    [TitleGroup("TitleAlignments_Right", "可选副标题", alignment: TitleAlignments.Right)]
    public string titleRight = "";
    [TitleGroup("TitleAlignments_Split", "可选副标题", alignment: TitleAlignments.Split)]
    public string titleSplit = "";

    [PropertySpace(40)]
    public string DynamicTitle = "DynamicTitle";
    [TitleGroup("$DynamicTitle", "Optional subtitle")]
    public string SomeString1;

    [TitleGroup("Vectors", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: true)]
    public Vector2 SomeVector0;
    [TitleGroup("Vectors_Indent", "Optional subtitle", alignment: TitleAlignments.Centered, horizontalLine: true, boldTitle: true, indent: false)]
    public Vector2 SomeVector1;

    [TitleGroup("NoTitle", horizontalLine:false)]
    public string noTitleStr = "noTitleStrContent";
}