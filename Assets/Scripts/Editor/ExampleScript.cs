using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class ExampleScript : MonoBehaviour
{
    [FilePath(Extensions = ".unity")]
    public string ScenePath;
    [FilePath(Extensions = ".cs")]
    public string ScriptsPath;

    [HideInInspector]
    public int NormallyVisible;

    [ShowInInspector]
    private bool normallyHidden;

    [ShowInInspector]
    public ScriptableObject Property { get; set; }

    [Button(ButtonSizes.Large)]
    public void SayHello()
    {
        Debug.Log("Hello button!");
        //Debug.Log($"路径为{ScenePath}");
    }

    [PreviewField, Required, AssetsOnly]
    public GameObject Prefab;

    [HideLabel, Required, PropertyOrder(-5)]
    public string Name { get; set; }
    [HideLabel, Required, PropertyOrder(-0)]
    public GameObject MyGameObjectWithoutLabel;

    [Button(ButtonSizes.Medium), PropertyOrder(-3)]
    public void RandomName()
    {
        this.Name = Guid.NewGuid().ToString();
    }

    [HorizontalGroup("Split", Width = 50), HideLabel, PreviewField(50)]
    public Texture2D Icon;

    [VerticalGroup("Split/Properties")]
    public string MinionName;

    [VerticalGroup("Split/Properties")]
    public float Health;

    [VerticalGroup("Split/Properties")]
    public float Damage;

    [VerticalGroup("Split/Properties/Value0")]
    public float Value0;
    [VerticalGroup("Split/Properties/Value1")]
    public float Value1;
    [VerticalGroup("Split/Properties/Value2")]
    public float Value2;

    [LabelText("$IAmLabel")]
    public string IAmLabel;



    [ListDrawerSettings(
        CustomAddFunction = "CreateNewGUID",
        CustomRemoveIndexFunction = "RemoveGUID")]
    public List<string> GuidList;

    private string CreateNewGUID()
    {
        return Guid.NewGuid().ToString();
    }

    private void RemoveGUID(int index)
    {
        this.GuidList.RemoveAt(index);
    }

    [TabGroup("First Tab")]
    public int FirstTab;

    [ShowInInspector, TabGroup("First Tab")]
    public int SecondTab { get; set; }

    [TabGroup("Second Tab")]
    public float FloatValue;

    [TabGroup("Second Tab"), Button]
    public void Button()
    {

    }

    [Button(ButtonSizes.Large)]
    [FoldoutGroup("Buttons in Boxes")]
    [HorizontalGroup("Buttons in Boxes/Horizontal", Width = 100)]
    [BoxGroup("Buttons in Boxes/Horizontal/One")]
    public void Button1() { }

    [Button(ButtonSizes.Large)]
    [BoxGroup("Buttons in Boxes/Horizontal/Two")]
    public void Button2() { }

    [Button]
    [BoxGroup("Buttons in Boxes/Horizontal/Double")]
    public void Accept() { }

    [Button]
    [BoxGroup("Buttons in Boxes/Horizontal/Double")]
    public void Cancel() { }
}
