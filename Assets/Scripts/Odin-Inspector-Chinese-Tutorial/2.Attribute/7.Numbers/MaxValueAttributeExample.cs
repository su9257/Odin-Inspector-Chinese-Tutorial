using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxValueAttributeExample : MonoBehaviour
{
    // Ints
    [Title("Int")]
    [MinValue(0)]
    public int IntMinValue0;

    [MaxValue(0)]
    public int IntMaxValue0;

    // Floats
    [Title("Float")]
    [MinValue(0)]
    public float FloatMinValue0;

    [MaxValue(0)]
    public float FloatMaxValue0;

    // Vectors
    [Title("Vectors")]
    [MinValue(0)]
    public Vector3 Vector3MinValue0;

    [MaxValue(0)]
    public Vector3 Vector3MaxValue0;
}
