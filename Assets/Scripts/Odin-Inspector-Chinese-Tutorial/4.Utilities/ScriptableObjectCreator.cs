using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectCreator : OdinMenuEditorWindow
{
    static HashSet<Type> scriptableObjectTypes = AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes)
        .Where(t =>
            t.IsClass &&
            typeof(ScriptableObject).IsAssignableFrom(t) &&
            !typeof(EditorWindow).IsAssignableFrom(t) &&
            !typeof(Editor).IsAssignableFrom(t))
       .ToHashSet();

    [MenuItem("Assets/Create Scriptable Object", priority = -1000)]
    private static void ShowDialog()
    {
        var path = "Assets";
        var obj = Selection.activeObject;
        if (obj && AssetDatabase.Contains(obj))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!Directory.Exists(path))
            {
                path = Path.GetDirectoryName(path);
            }
        }

        var window = CreateInstance<ScriptableObjectCreator>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
        window.titleContent = new GUIContent(path);
        window.targetFolder = path.Trim('/');//避免出现 / 造成路径不对
        window.ShowUtility();
    }

    private ScriptableObject previewObject;
    private string targetFolder;
    private Vector2 scroll;

    private Type SelectedType
    {
        get
        {
            var m = MenuTree.Selection.LastOrDefault();
            return m == null ? null : m.Value as Type;
        }
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        MenuWidth = 270;
        WindowPadding = Vector4.zero;

        OdinMenuTree tree = new OdinMenuTree(false);//不支持多选
        tree.Config.DrawSearchToolbar = true;
        tree.DefaultMenuStyle = OdinMenuStyle.TreeViewStyle;
        tree.AddRange(scriptableObjectTypes.Where(x => !x.IsAbstract), GetMenuPathForType).AddThumbnailIcons();
        tree.SortMenuItemsByName();
        tree.Selection.SelectionConfirmed += x => 
        {
            Debug.Log($"双击确认并创建：{x}");
            this.CreateAsset();
        };
        tree.Selection.SelectionChanged += e =>
        {
            Debug.Log($"单击选择回调{e}");
            if (this.previewObject && !AssetDatabase.Contains(this.previewObject))
            {
                DestroyImmediate(previewObject);
            }

            if (e != SelectionChangedType.ItemAdded)
            {
                return;
            }

            var t = SelectedType;
            if (t != null && !t.IsAbstract)
            {
                previewObject = CreateInstance(t) as ScriptableObject;
            }
        };
        return tree;
    }

    private string GetMenuPathForType(Type t)
    {
        if (t != null && scriptableObjectTypes.Contains(t))
        {
            var name = t.Name.Split('`').First().SplitPascalCase();
            return GetMenuPathForType(t.BaseType) + "/" + name;
        }
        return "";
    }

    protected override IEnumerable<object> GetTargets()
    {
        yield return previewObject;
    }

    protected override void DrawEditor(int index)
    {
        scroll = GUILayout.BeginScrollView(scroll);
        {
            base.DrawEditor(index);
        }
        GUILayout.EndScrollView();

        if (this.previewObject)
        {
            GUILayout.FlexibleSpace();
            SirenixEditorGUI.HorizontalLineSeparator(1);
            if (GUILayout.Button("Create Asset", GUILayoutOptions.Height(30)))
            {
                CreateAsset();
            }
        }
    }

    private void CreateAsset()
    {
        if (previewObject)
        {
            var dest = targetFolder + "/new " + MenuTree.Selection.First().Name.ToLower() + ".asset";
            dest = AssetDatabase.GenerateUniqueAssetPath(dest);
            AssetDatabase.CreateAsset(previewObject, dest);
            AssetDatabase.Refresh();
            Selection.activeObject = previewObject;
            EditorApplication.delayCall += Close;
        }
    }
}