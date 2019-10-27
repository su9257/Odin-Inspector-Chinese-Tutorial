using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDuplicateReferenceBoxAttributeExample : MonoBehaviour
{
    [ShowInInspector]
    public ReferenceTypeClass firstObject;
    [ShowInInspector]
    public ReferenceTypeClass withReferenceBox;
    [ShowInInspector]
    [HideDuplicateReferenceBox]
    public ReferenceTypeClass withoutReferenceBox;
    

    [Button("初始化",ButtonSizes.Large)]
    public void Setup()
    {
        this.firstObject = new ReferenceTypeClass();
        this.withReferenceBox = this.firstObject;
        this.withoutReferenceBox = this.firstObject;
        this.firstObject.recursiveReference = this.firstObject;
    }

    public partial class ReferenceTypeClass
    {
        [HideDuplicateReferenceBox]
        public ReferenceTypeClass recursiveReference;
    }
}
