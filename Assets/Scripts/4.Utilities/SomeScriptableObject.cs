using Sirenix.OdinInspector;
using UnityEngine;



// 
// Test data - you can delete this part or name the file SomeScriptableObject.cs and try it out
// 
[CreateAssetMenu]
public class SomeScriptableObject : SerializedScriptableObject
{
    [ShowInInspector]
    [LabelText("$testName")]
    public static SomeData test = new SomeData();

    public string testName()
    {
        return test.Name;
    }
}

[PageSlider, HideReferenceObjectPicker]
public class SomeData
{
    public string Name;
    public int b, c, d;
    public SomeData b1, c1, d2;
    [ListDrawerSettings(Expanded = true)]
    public SomeData[] a = new SomeData[3];

    [ListDrawerSettings(Expanded = true), InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Foldout, Expanded = true)]
    [PageSlider]
    public Material[] e = new Material[0];
    public int f, g, h;


    public override string ToString()
    {
        return this.Name ?? "Some Data";
    }
}

