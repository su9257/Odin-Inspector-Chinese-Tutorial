using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyOrderExample : MonoBehaviour
{
    [PropertyOrder(1)]
    public int Second;

    [InfoBox("PropertyOrder用于更改inspector中属性的顺序")]
    [PropertyOrder(-1)]
    public int First;
}
