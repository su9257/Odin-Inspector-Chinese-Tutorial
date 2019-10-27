using Sirenix.OdinInspector;
using UnityEngine;

public class MaxValueAttributeExample : MonoBehaviour
{
    [MaxValue(0)]
    public int IntMaxValue0;

    [MaxValue(0)]
    public float FloatMaxValue0;

    [MaxValue(0)]
    public Vector3 Vector3MaxValue0;
}
