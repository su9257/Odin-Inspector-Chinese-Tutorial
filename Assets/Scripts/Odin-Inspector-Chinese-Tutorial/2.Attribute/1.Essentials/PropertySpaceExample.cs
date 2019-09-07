using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertySpaceExample : MonoBehaviour
{

    [Space]
    public int Space;

    [Space(5)]
    public int Space1;
    [Space(10)]
    public int Space2;

    [ShowInInspector, PropertySpace]
    public int Property { get; set; }

    // 还可以控制PropertySpace属性前后的间距。
    [PropertySpace(SpaceBefore = 0, SpaceAfter = 60), PropertyOrder(2)]
    public int BeforeAndAfter;
    [PropertyOrder(3)]
    public int BeforeAndAfter1;
}
