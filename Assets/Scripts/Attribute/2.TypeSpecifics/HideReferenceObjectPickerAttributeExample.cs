using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;


public class HideReferenceObjectPickerAttributeExample : MonoBehaviour
{
    [Title("Hidden Object Pickers")]
    [ShowInInspector]
    [HideReferenceObjectPicker]
    public MyCustomReferenceType OdinSerializedProperty1 = new MyCustomReferenceType();
    [ShowInInspector]
    [HideReferenceObjectPicker]
    public MyCustomReferenceType OdinSerializedProperty2 = new MyCustomReferenceType();
    [ShowInInspector]
    [Title("Shown Object Pickers")]
    public MyCustomReferenceType OdinSerializedProperty3 = new MyCustomReferenceType();
    [ShowInInspector]
    public MyCustomReferenceType OdinSerializedProperty4 = new MyCustomReferenceType();

    // Protip: You can also put the HideInInspector attribute on the class definition itself to hide it globally for all members.
    //[HideReferenceObjectPicker]
    public class MyCustomReferenceType
    {
        public int A;
        public int B;
        public int C;
    }
}


