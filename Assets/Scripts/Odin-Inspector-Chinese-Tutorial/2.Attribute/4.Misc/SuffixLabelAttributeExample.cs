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
        "使用Overlay属性，后缀标签将绘制在属性的顶部而不是后面.\n" +
        "使用它可以获得整洁的行内外观.")]
    [SuffixLabel("ms", Overlay = false)]
    public float Speed;

    [SuffixLabel("radians", Overlay = true)]
    public float Angle;

    [Space(15)]
    [InfoBox("Suffix 属性还支持通过使用$来引用成员字符串字段、属性或方法.")]
    [SuffixLabel("$Suffix", Overlay = true)]
    public string Suffix = "Dynamic suffix label";

    [InfoBox("Suffix属性还支持使用@表达式 .")]
    [SuffixLabel("@DateTime.Now.ToString(\"HH:mm:ss\")", true)]
    public string Expression;
}
