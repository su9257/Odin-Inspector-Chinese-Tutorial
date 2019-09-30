using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttributeExample : MonoBehaviour
{
    [Range(0, 10)]
    public int Field = 2;

    [InfoBox("Odin's PropertyRange attribute is similar to Unity's Range attribute, but also works on properties.")]
    [ShowInInspector, PropertyRange(0, 10)]
    public int Property { get; set; }

    [InfoBox("You can also reference member for either or both min and max values.")]
    [PropertyRange(0, "Max"), PropertyOrder(3)]
    public int Dynamic = 6;

    [PropertyOrder(4)]
    public int Max = 100;
}
