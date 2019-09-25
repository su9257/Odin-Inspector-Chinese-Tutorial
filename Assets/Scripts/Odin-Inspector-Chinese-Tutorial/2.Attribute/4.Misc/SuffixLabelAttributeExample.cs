using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuffixLabelAttributeExample : MonoBehaviour
{
    [SuffixLabel("Prefab")]
    public GameObject GameObject;

    [Space(15)]
    [InfoBox(
        "Using the Overlay property, the suffix label will be drawn on top of the property instead of behind it.\n" +
        "Use this for a neat inline look.")]
    [SuffixLabel("ms", Overlay = false)]
    public float Speed;

    [SuffixLabel("radians", Overlay = true)]
    public float Angle;

    [Space(15)]
    [InfoBox("The Suffix attribute also supports referencing a member string field, property, or method by using $.")]
    [SuffixLabel("$Suffix", Overlay = true)]
    public string Suffix = "Dynamic suffix label";

    [InfoBox("The Suffix attribute also supports expressions by using @.")]
    [SuffixLabel("@DateTime.Now.ToString(\"HH:mm:ss\")", true)]
    public string Expression;
}
