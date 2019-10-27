using UnityEngine;
using Sirenix.OdinInspector;
using System;
using System.Linq;
using System.Collections.Generic;

public class ColorPaletteAttributeExample : MonoBehaviour
{
    [ColorPalette]
    public Color ColorOptions;

    [PropertySpace(50)]
    [ColorPalette("Underwater")]
    public Color UnderwaterColor;
    [PropertySpace(50)]
    [ColorPalette("我的调色板")]
    public Color MyColor;

    [PropertySpace(50)]
    [ColorPalette("海澜调色板1",ShowAlpha = true)]
    public Color MyColor_Apha;

    // ColorPalette属性同时支持成员引用和属性表达式。
    [PropertySpace(50)]
    [ColorPalette("$DynamicPaletteName")]
    public Color DynamicPaletteColor1;
    public string DynamicPaletteName = "Clovers";

    [PropertySpace(10)]
    [PropertyRange(1,10)]
    public int DynamicPaletteColor2Index = 0;
    [ColorPalette("@\"海澜调色板\"+ DynamicPaletteColor2Index")]
    public Color DynamicPaletteColor2;


    [PropertySpace(50)]
    [ColorPalette("Fall"), HideLabel]
    public Color WideColorPalette;

    [PropertySpace(50,50)]
    [ColorPalette("菜鸟海澜调色板")]
    public Color[] ColorArray;

    // ------------------------------------
    // Color palettes can be accessed and modified from code.
    // Note that the color palettes will NOT automatically be included in your builds.
    // But you can easily fetch all color palettes via the ColorPaletteManager 
    // and include them in your game like so:
    // 调色板可以通过代码访问和修改。注意，调色板不会自动包含在您的构建中。
    // 但是你可以很容易地通过ColorPaletteManager获取所有的调色板，并将它们包括在你的游戏中，就像这样:
    // ------------------------------------
    [FoldoutGroup("Color Palettes", expanded: false)]
    [ListDrawerSettings(IsReadOnly = true)]
    [PropertyOrder(9)]
    public List<ColorPalette> ColorPalettes;

#if UNITY_EDITOR

    [FoldoutGroup("Color Palettes"), Button("获取调色板",ButtonSizes.Large), GUIColor(0, 1, 0), PropertyOrder(8)]
    private void FetchColorPalettes()
    {
        this.ColorPalettes = Sirenix.OdinInspector.Editor.ColorPaletteManager.Instance.ColorPalettes
            .Select(x => new ColorPalette()
            {
                Name = x.Name,
                Colors = x.Colors.ToArray()
            })
            .ToList();
    }

#endif
    [Serializable]
    public class ColorPalette
    {
        [HideInInspector]
        public string Name;

        [LabelText("$Name")]
        [ListDrawerSettings(IsReadOnly = true, Expanded = false)]//IsReadOnly是否可以删除序列化数组  Expanded覆盖默认设置，是否展开，false为不展开状态
        public Color[] Colors;
    }
}