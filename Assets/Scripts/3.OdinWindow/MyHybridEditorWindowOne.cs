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

public class MyHybridEditorWindowOne : OdinEditorWindow
{
    [MenuItem("My Game/My Hybrid Editor")]
    private static void OpenWindow()
    {
        GetWindow<MyHybridEditorWindowOne>().Show();
    }

    [EnumToggleButtons, BoxGroup("Settings")]
    public ScaleMode ScaleMode;

    [FolderPath(RequireExistingPath = true), BoxGroup("Settings")]
    public string OutputPath;

    
    [HorizontalGroup(0.5f)]//占比0.5
    public List<Texture> InputTextures;

    [HorizontalGroup, InlineEditor(InlineEditorModes.LargePreview)]
    public Texture Preview;

    [Button(ButtonSizes.Gigantic), GUIColor(0, 1, 0)]
    public void PerformSomeAction()
    {

    }
}
