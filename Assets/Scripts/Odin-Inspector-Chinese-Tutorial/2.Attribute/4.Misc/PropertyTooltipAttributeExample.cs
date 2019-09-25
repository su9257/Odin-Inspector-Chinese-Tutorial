using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyTooltipAttributeExample : MonoBehaviour
{
    [PropertyTooltip("This is tooltip on an int property.")]
    public int MyInt;

    [InfoBox("Use $ to refer to a member string.")]
    [PropertyTooltip("$Tooltip")]
    public string Tooltip = "Dynamic tooltip.";

    [Button, PropertyTooltip("Button Tooltip")]
    private void ButtonWithTooltip()
    {
        // ...
    }
}
