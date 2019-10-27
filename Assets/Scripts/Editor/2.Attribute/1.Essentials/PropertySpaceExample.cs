using Sirenix.OdinInspector;
using UnityEngine;

public class PropertySpaceExample : MonoBehaviour
{
    [Space]
    public int unitySpace;

    [Space(5)]
    public int unitySpace1;
    [PropertySpace]
    public int OdinSpace2;

    [ShowInInspector, PropertySpace]
    public int Property { get; set; }

    // 还可以控制PropertySpace属性前后的间距。
    [PropertySpace(SpaceBefore = 30, SpaceAfter = 30)]
    public int BeforeAndAfter;
    [PropertySpace(SpaceBefore = 30, SpaceAfter = 30)]
    public int BeforeAndAfter1;
}
