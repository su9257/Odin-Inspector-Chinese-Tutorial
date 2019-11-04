using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/*
 * 通过从OdinEditorWindow而不是EditorWindow继承，您可以使Unity编辑器窗口的方式与创建检查器的方式完全相同：仅使用属性。

提示：您可以使用 OnInspectorGUI 属性，如果您希望将自定义编辑器IMGUI代码与Odin绘制的编辑器混合使用
 */
public class SomeWindow : OdinEditorWindow
{
    [MenuItem("My Game/My Window")]
    private static void OpenWindow()
    {
        GetWindow<SomeWindow>().Show();
    }

    [PropertyOrder(-10)]
    [HorizontalGroup]
    [Button(ButtonSizes.Large)]
    public void SomeButton1() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large)]
    public void SomeButton2() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large)]
    public void SomeButton3() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
    public void SomeButton4() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large), GUIColor(1, 0.5f, 0)]
    public void SomeButton5() { }

    [TableList]
    public List<SomeType> SomeTableData;
}

public class SomeType
{
    [TableColumnWidth(50)]
    public bool Toggle;

    [AssetsOnly]
    public GameObject SomePrefab;

    public string Message;

    [TableColumnWidth(160)]
    [HorizontalGroup("Actions")]
    public void Test1() { }

    [HorizontalGroup("Actions")]
    public void Test2() { }
}
