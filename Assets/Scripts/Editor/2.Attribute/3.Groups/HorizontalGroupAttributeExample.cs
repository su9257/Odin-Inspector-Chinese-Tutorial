using Sirenix.OdinInspector;
using UnityEngine;

public class HorizontalGroupAttributeExample : MonoBehaviour
{
    [HorizontalGroup]
    public int A;
    [HorizontalGroup("Group 1", LabelWidth = 20)]
    public int C;
    [HorizontalGroup("Group 1")]
    public int D;
    [HorizontalGroup("Group 1")]
    public int E;
    [PropertySpace(40, 40)]
    public string space = "";

    [HorizontalGroup("Split", 0.5f, LabelWidth = 40)]
    [BoxGroup("Split/Left")]
    public int L;
    [BoxGroup("Split/Left")]
    public int N;
    [BoxGroup("Split/Right")]
    public int M;
    [BoxGroup("Split/Right")]
    public int O;

    [PropertySpace(40, 40)]
    public string space1 = "";

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
}