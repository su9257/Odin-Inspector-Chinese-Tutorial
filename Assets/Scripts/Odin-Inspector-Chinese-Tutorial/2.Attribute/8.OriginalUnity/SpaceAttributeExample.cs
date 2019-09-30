using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAttributeExample : MonoBehaviour
{
    // Delayed and Space attributes are virtually identical...
    [Space]
    public int Space;

    // ... but the PropertySpace can, as the name suggests, also be applied to properties.
    [ShowInInspector, PropertySpace]
    public string Property { get; set; }

    // You can also control spacing both before and after the PropertySpace attribute.
    [PropertySpace(SpaceBefore = 0, SpaceAfter = 60), PropertyOrder(2)]
    public int BeforeAndAfter;
}
