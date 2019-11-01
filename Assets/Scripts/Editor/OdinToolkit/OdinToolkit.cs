using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using System;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

public class OdinToolkit : OdinMenuEditorWindow
{
    [MenuItem("Tools/Odin工具箱")]
    private static void OpenWindow()
    {
        var window = GetWindow<OdinToolkit>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(1000, 500);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree(false, OdinMenuStyle.TreeViewStyle);
        tree.Config.DrawSearchToolbar = true;
        tree.DefaultMenuStyle.Height = 50;
        tree.DefaultMenuStyle.IconSize = 40;

        this.titleContent = new GUIContent("Odin 工具箱");

        #region 工具箱功能列表
        tree.Add("菜单风格设置", tree.DefaultMenuStyle,EditorIcons.House);
        tree.Add("Ediator 协程", CreateInstance(typeof(EditorCoroutineDemo)), EditorIcons.Timer);
        tree.Add("一键搜索重复文件", CreateInstance(typeof(OneKeySearchDuplicateFiles)),EditorIcons.FileCabinet) ;
        tree.Add("一键更改Raycast", CreateInstance(typeof(OneKeyChangeRaycastTarget)), EditorIcons.RulerRect);
        #endregion

        return tree;
    }

    public OdinMenuStyle ReturnOdinMenuStyle()
    {
        OdinMenuStyle odinMenuStyle =    new OdinMenuStyle()
        {
            Height = 50,
            Offset = 20.00f,
            IndentAmount = 15.00f,
            IconSize = 35,
            IconOffset = 0.00f,
            NotSelectedIconAlpha = 0.85f,
            IconPadding = 0.00f,
            TriangleSize = 16.00f,
            TrianglePadding = 0.00f,
            AlignTriangleLeft = true,
            Borders = true,
            BorderPadding = 0.00f,
            BorderAlpha = 0.32f,
            SelectedColorDarkSkin = new Color(0.243f, 0.373f, 0.588f, 1.000f),
            SelectedColorLightSkin = new Color(0.243f, 0.490f, 0.900f, 1.000f)
        };
        return odinMenuStyle;
    }
}


