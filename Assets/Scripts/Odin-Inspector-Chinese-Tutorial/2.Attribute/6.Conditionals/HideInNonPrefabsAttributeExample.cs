using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInNonPrefabsAttributeExample : MonoBehaviour
{
    [HideInNonPrefabs] //非预制体时隐藏属性
    public GameObject HiddenInNonPrefabs;
}
