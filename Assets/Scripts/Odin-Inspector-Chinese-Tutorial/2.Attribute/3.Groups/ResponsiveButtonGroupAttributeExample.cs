using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveButtonGroupAttributeExample : MonoBehaviour
{
    [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
    private void OpenDockableWindowExample()
    {
        //var window = UnityEditor.EditorWindow.GetWindow<MyDockableGameDashboard>();
        //window.WindowPadding = new Vector4();
    }

    [OnInspectorGUI] private void Space1() { GUILayout.Space(20); }

    [ResponsiveButtonGroup] public void Foo() { }
    [ResponsiveButtonGroup] public void Bar() { }
    [ResponsiveButtonGroup] public void Baz() { }

    [OnInspectorGUI] private void Space2() { GUILayout.Space(20); }

    [ResponsiveButtonGroup("UniformGroup", UniformLayout = true)] public void Foo1() { }
    [ResponsiveButtonGroup("UniformGroup")] public void Foo2() { }
    [ResponsiveButtonGroup("UniformGroup")] public void LongesNameWins() { }
    [ResponsiveButtonGroup("UniformGroup")] public void Foo4() { }
    [ResponsiveButtonGroup("UniformGroup")] public void Foo5() { }
    [ResponsiveButtonGroup("UniformGroup")] public void Foo6() { }

    [OnInspectorGUI] private void Space3() { GUILayout.Space(20); }

    [ResponsiveButtonGroup("DefaultButtonSize", DefaultButtonSize = ButtonSizes.Small)] public void Bar1() { }
    [ResponsiveButtonGroup("DefaultButtonSize")] public void Bar2() { }
    [ResponsiveButtonGroup("DefaultButtonSize")] public void Bar3() { }
    [Button(ButtonSizes.Large), ResponsiveButtonGroup("DefaultButtonSize")] public void Bar4() { }
    [Button(ButtonSizes.Large), ResponsiveButtonGroup("DefaultButtonSize")] public void Bar5() { }
    [ResponsiveButtonGroup("DefaultButtonSize")] public void Bar6() { }

    [OnInspectorGUI] private void Space4() { GUILayout.Space(20); }

    [FoldoutGroup("SomeOtherGroup")]
    [ResponsiveButtonGroup("SomeOtherGroup/SomeBtnGroup")] public void Baz1() { }
    [ResponsiveButtonGroup("SomeOtherGroup/SomeBtnGroup")] public void Baz2() { }
    [ResponsiveButtonGroup("SomeOtherGroup/SomeBtnGroup")] public void Baz3() { }

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