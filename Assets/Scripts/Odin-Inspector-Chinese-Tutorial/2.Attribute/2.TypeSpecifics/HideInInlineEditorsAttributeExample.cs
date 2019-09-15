using Sirenix.OdinInspector;
using UnityEngine;

    public class HideInInlineEditorsAttributeExample : MonoBehaviour
    {
    [InfoBox("Click the pen icon to open a new inspector window for the InlineObject too see the differences these attributes make.")]
    [InlineEditor(Expanded = true)]
    public MyInlineScriptableObject InlineObject;

    private void Start()
        {
            InlineObject =  ExampleHelper.GetScriptableObject<MyInlineScriptableObject>();
        }
    }