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
    /// <summary>
    /// 获取继承 ScriptableObject 且不是Editor相关的所有自定义类（也就是自己编写的类）
    /// </summary>
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
        var obj = Selection.activeObject; //当前鼠标选中的 Object
        if (obj && AssetDatabase.Contains(obj))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!Directory.Exists(path))//主要用来判断所选的是文件还是文件夹
            {
                path = Path.GetDirectoryName(path);//如果是文件则获取对应文件夹的全名称
            }
        }
        //设置窗口对应属性
        var window = CreateInstance<ScriptableObjectCreator>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);//设置窗口的宽和高
        window.titleContent = new GUIContent(path);
        window.targetFolder = path.Trim('/');//避免出现 / 造成路径不对
        window.ShowUtility();
    }

    /// <summary>
    /// 选中的 ScriptableObject（等待创建）
    /// </summary>
    private ScriptableObject previewObject;
    /// <summary>
    /// 创建 ScriptableObject 时文件存储的目标文件夹
    /// </summary>
    private string targetFolder;
    private Vector2 scroll;

    private Type SelectedType
    {
        get
        {
            var m = MenuTree.Selection.LastOrDefault();//因为可以多选，所以返回选中的是一个列表，这里返回的是列表的最后一个Object
            return m == null ? null : m.Value as Type;
        }
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        MenuWidth = 300;//菜单的宽度
        WindowPadding = Vector4.zero;

        OdinMenuTree tree = new OdinMenuTree(false);//不支持多选
        tree.Config.DrawSearchToolbar = true;//开启搜索状态
        tree.DefaultMenuStyle = OdinMenuStyle.TreeViewStyle;//菜单设置成树形模式

        //筛选所有非抽象的类 并获取对应的路径
        tree.AddRange(scriptableObjectTypes.Where(x => !x.IsAbstract), GetMenuPathForType).AddThumbnailIcons();
        tree.SortMenuItemsByName();
        tree.Selection.SelectionConfirmed += x => 
        {
            Debug.Log($"双击确认并创建：{x}");
            this.CreateAsset();
        };
        tree.Selection.SelectionChanged += e =>
        {
            //每当选择发生更改时发生进行回调2次，一次SelectionCleared 一次是ItemAdded
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
            var name = t.Name.Split('`').First().SplitPascalCase();//主要是为了去除泛型相关 例如：Sirenix.Utilities.GlobalConfig`1[Sirenix.Serialization.GlobalSerializationConfig]
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
        //scroll 内容滑动条的XY坐标
        scroll = GUILayout.BeginScrollView(scroll);
        {
            base.DrawEditor(index);
        }
        GUILayout.EndScrollView();

        if (this.previewObject)
        {
            GUILayout.FlexibleSpace();//插入一个空隙
            SirenixEditorGUI.HorizontalLineSeparator(5);//插入一个水平分割线
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
            dest = AssetDatabase.GenerateUniqueAssetPath(dest);//创建唯一路径 重名后缀 +1
            Debug.Log($"要创建的为{previewObject}");
            AssetDatabase.CreateAsset(previewObject, dest);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Selection.activeObject = previewObject;
            EditorApplication.delayCall += Close;//如不需要创建后自动关闭可将本行注释
        }
    }
}