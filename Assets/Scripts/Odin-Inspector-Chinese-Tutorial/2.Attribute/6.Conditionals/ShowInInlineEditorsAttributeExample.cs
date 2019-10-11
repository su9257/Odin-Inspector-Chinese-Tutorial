using Sirenix.OdinInspector;
using UnityEngine;

public class ShowInInlineEditorsAttributeExample : MonoBehaviour
{
    [InfoBox("单击属性值打开一个新的检查窗口，也可以看到这些属性的不同.")]
    [InlineEditor(Expanded = true)]
    public MyInlineScriptableObject InlineObject;
}
