using UnityEngine;
using Sirenix.OdinInspector;

public class DisplayAsStringAttributeExample : MonoBehaviour
{ 
    [DisplayAsString]
    public Color SomeColor;

    [PropertySpace(40)]
    [DisplayAsString]
    public GameObject Obj;

    [PropertySpace(40)]
    [HideLabel]
    [DisplayAsString]
    public string SomeText = "SomeText对应的Label已经被隐藏，你现在看到的是他对应的内容（Value）";

    [PropertySpace(40)]
    [HideLabel]
    [DisplayAsString]
    public string Overflow = "A very very very very very very very very very long string that has been configured to overflow.";

    [PropertySpace(40)]
    [HideLabel]
    [DisplayAsString(false)]//这是为false时，如果inspector显示空间不足，则自动换行
    public string DisplayAllOfIt = "A very very very very very very very very long string that has been configured to not overflow.";
}