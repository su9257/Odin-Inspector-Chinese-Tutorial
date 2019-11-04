using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPropertyResolverAttributeExample : MonoBehaviour
{
    [ShowPropertyResolver]
    public string MyString;

    [ShowPropertyResolver]
    public List<int> MyList;

    [ShowInInspector]
    [ShowPropertyResolver]
    public Dictionary<int, Vector3> MyDictionary;
}
