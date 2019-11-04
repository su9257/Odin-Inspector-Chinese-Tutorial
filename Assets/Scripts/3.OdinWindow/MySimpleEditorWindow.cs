using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.OdinValidator;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MySimpleEditorWindow : OdinEditorWindow
{
    [MenuItem("My Game/My Simple Editor")]
    private static void OpenWindow()
    {
        GetWindow<MySimpleEditorWindow>().Show();
    }

    public string Hello = "菜鸟海澜";
}
