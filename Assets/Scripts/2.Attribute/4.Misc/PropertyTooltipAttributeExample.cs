using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyTooltipAttributeExample : MonoBehaviour
{
    [PropertyTooltip("放在属性上显示对应的悬停提示.")]
    public int MyInt;

    [InfoBox("使用$引用成员字符串.")]
    [PropertyTooltip("$Tooltip")]
    public string Tooltip = "Dynamic tooltip.";

    [Button, PropertyTooltip("Button Tooltip")]
    private void ButtonWithTooltip()
    {
        // ...
    }
}
