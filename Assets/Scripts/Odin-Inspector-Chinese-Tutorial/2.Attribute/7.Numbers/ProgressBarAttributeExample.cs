using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarAttributeExample : MonoBehaviour
{
    [ProgressBar(0, 100)]
    public int ProgressBar = 50;

    [HideLabel]
    [ProgressBar(-100, 100, r: 1, g: 1, b: 1, Height = 30)]
    public short BigColoredProgressBar = 50;

    [ProgressBar(0, 10, 0, 1, 0, Segmented = true)]
    public int SegmentedColoredBar = 5;

    [ProgressBar(0, 100, ColorMember = "GetHealthBarColor")]
    public float DynamicHealthBarColor = 50;

    // The min and max properties also support attribute expressions with the $ symbol.
    [BoxGroup("Dynamic Range")]
    [ProgressBar("Min", "Max")]
    public float DynamicProgressBar = 50;

    [BoxGroup("Dynamic Range")]
    public float Min;

    [BoxGroup("Dynamic Range")]
    public float Max = 100;

    [Range(0, 300)]
    [BoxGroup("Stacked Health"), HideLabel]
    public float StackedHealth = 150;

    [HideLabel, ShowInInspector]
    [ProgressBar(0, 100, ColorMember = "GetStackedHealthColor", BackgroundColorMember = "GetStackHealthBackgroundColor", DrawValueLabel = false)]
    [BoxGroup("Stacked Health")]
    private float StackedHealthProgressBar
    {
        get { return this.StackedHealth % 100.01f; }
    }

    private Color GetHealthBarColor(float value)
    {
        return Color.Lerp(Color.red, Color.green, Mathf.Pow(value / 100f, 2));
    }

    private Color GetStackedHealthColor()
    {
        return
            this.StackedHealth > 200 ? Color.white :
            this.StackedHealth > 100 ? Color.green :
            Color.red;
    }

    private Color GetStackHealthBackgroundColor()
    {
        return
            this.StackedHealth > 200 ? Color.green :
            this.StackedHealth > 100 ? Color.red :
            new Color(0.16f, 0.16f, 0.16f, 1f);
    }
}
