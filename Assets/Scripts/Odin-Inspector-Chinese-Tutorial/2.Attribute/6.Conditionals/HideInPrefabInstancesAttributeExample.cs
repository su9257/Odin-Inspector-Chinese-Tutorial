using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInPrefabInstancesAttributeExample : MonoBehaviour
{
    [HideInPrefabInstances]
    public GameObject HiddenInPrefabInstances;
}
