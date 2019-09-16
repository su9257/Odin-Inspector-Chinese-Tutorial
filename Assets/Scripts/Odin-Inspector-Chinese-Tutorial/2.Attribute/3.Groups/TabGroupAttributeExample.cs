using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroupAttributeExample : MonoBehaviour
{
    [TabGroup("Tab A")]
    public int One;

    [TabGroup("Tab A")]
    public int Two;

    [TabGroup("Tab A")]
    public int Three;

    [TabGroup("Tab B")]
    public string MyString;

    [TabGroup("Tab B")]
    public float MyFloat;

    [TabGroup("Tab C")]
    [HideLabel]
    public MyTabObject TabC;

    [TabGroup("New Group", "Tab A")]
    public int A;

    [TabGroup("New Group", "Tab A")]
    public int B;

    [TabGroup("New Group", "Tab A")]
    public int C;

    [TabGroup("New Group", "Tab B")]
    public string D;

    [TabGroup("New Group", "Tab B")]
    public float E;

    [TabGroup("New Group", "Tab C")]
    [HideLabel]
    public MyTabObject F;

    [Serializable]
    public class MyTabObject
    {
        public int A;
        public int B;
        public int C;
    }

    [TitleGroup("Tabs")]
    [HorizontalGroup("Tabs/Split", Width = 0.5f)]
    [TabGroup("Tabs/Split/Parameters", "A")]
    public string NameA, NameB, NameC;

    [TabGroup("Tabs/Split/Parameters", "B")]
    public int ValueA, ValueB, ValueC;

    [TabGroup("Tabs/Split/Buttons", "Responsive")]
    [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
    public void Hello() { }

    [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
    public void World() { }

    [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
    public void And() { }

    [ResponsiveButtonGroup("Tabs/Split/Buttons/Responsive/ResponsiveButtons")]
    public void Such() { }

    [Button]
    [TabGroup("Tabs/Split/Buttons", "More Tabs")]
    [TabGroup("Tabs/Split/Buttons/More Tabs/SubTabGroup", "A")]
    public void SubButtonA() { }

    [Button]
    [TabGroup("Tabs/Split/Buttons/More Tabs/SubTabGroup", "A")]
    public void SubButtonB() { }

    [Button(ButtonSizes.Gigantic)]
    [TabGroup("Tabs/Split/Buttons/More Tabs/SubTabGroup", "B")]
    public void SubButtonC() { }
}
