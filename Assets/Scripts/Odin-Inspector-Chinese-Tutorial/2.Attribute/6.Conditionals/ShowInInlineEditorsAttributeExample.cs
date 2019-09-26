using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInInlineEditorsAttributeExample : MonoBehaviour
{
    [InfoBox("Click the pen icon to open a new inspector window for the InlineObject too see the differences these attributes make.")]
    [InlineEditor(Expanded = true)]
    public MyInlineScriptableObject InlineObject;

    public class MyInlineScriptableObject : ScriptableObject
    {
        [ShowInInlineEditors]
        public string ShownInInlineEditor;

        [HideInInlineEditors]
        public string HiddenInInlineEditor;
    }
}
