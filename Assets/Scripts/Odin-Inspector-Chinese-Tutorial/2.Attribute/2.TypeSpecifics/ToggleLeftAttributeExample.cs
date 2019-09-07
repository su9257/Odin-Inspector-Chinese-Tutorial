using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLeftAttributeExample : MonoBehaviour
{
    [InfoBox("Draws the toggle button before the label for a bool property.")]
    [ToggleLeft]
    public bool LeftToggled;

    [EnableIf("LeftToggled")]
    public int A;

    [EnableIf("LeftToggled")]
    public bool B;

    [EnableIf("LeftToggled")]
    public bool C;
}
