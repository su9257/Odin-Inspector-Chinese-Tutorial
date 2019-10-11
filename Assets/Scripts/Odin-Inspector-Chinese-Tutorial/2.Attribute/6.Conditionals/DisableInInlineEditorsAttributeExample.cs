using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInInlineEditorsAttributeExample : MonoBehaviour
{
    [InfoBox("Click the pen icon to open a new inspector window for the InlineObject too see the difference this attribute make.")]
    [InlineEditor(Expanded = true)]
    public MyInlineScriptableObject InlineObject ;
}
