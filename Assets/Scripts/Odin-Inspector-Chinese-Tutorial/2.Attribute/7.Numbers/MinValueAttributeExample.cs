using Sirenix.OdinInspector;
using UnityEngine;

public class MinValueAttributeExample : MonoBehaviour
{
    // Ints
    [Title("Int")]
    [MinValue(0)]
    public int IntMinValue0;

    // Floats
    [Title("Float")]
    [MinValue(0)]
    public float FloatMinValue0;

    // Vectors
    [Title("Vectors")]
    [MinValue(0)]
    public Vector3 Vector3MinValue0;
}
