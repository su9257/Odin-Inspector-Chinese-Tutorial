using UnityEngine;
using Sirenix.OdinInspector;

public class DisplayAsStringAttributeExample : MonoBehaviour
{
    [InfoBox(
        "Instead of disabling values in the inspector in order to show some information or debug a value. " +
        "You can use DisplayAsString to show the value as text, instead of showing it in a disabled drawer")]
    [DisplayAsString]
    public Color SomeColor;

    [DisplayAsString]
    public GameObject Obj;

    [BoxGroup("SomeBox")]
    [HideLabel]
    [DisplayAsString]
    public string SomeText = "Lorem Ipsum";

    [InfoBox("The DisplayAsString attribute can also be configured to enable or disable overflowing to multiple lines.")]
    [HideLabel]
    [DisplayAsString]
    public string Overflow = "A very very very very very very very very very long string that has been configured to overflow.";

    [HideLabel]
    [DisplayAsString(false)]//这是为false时，如果inspector显示空间不足，则自动换行
    public string DisplayAllOfIt = "A very very very very very very very very long string that has been configured to not overflow.";
}


