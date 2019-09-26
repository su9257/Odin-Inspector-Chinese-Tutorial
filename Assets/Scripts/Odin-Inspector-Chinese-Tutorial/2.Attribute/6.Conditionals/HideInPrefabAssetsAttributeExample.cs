using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInPrefabAssetsAttributeExample : MonoBehaviour
{
    [InfoBox("These attributes will only have an effect when inspecting a GameObject's component.")]
    [HideInPrefabAssets]
    public GameObject HiddenInPrefabAssets;

    [HideInPrefabInstances]
    public GameObject HiddenInPrefabInstances;

    [HideInPrefabs]
    public GameObject HiddenInPrefabs;

    [HideInNonPrefabs]
    public GameObject HiddenInNonPrefabs;

    [DisableInPrefabAssets]
    public GameObject DisabledInPrefabAssets;

    [DisableInPrefabInstances]
    public GameObject DisabledInPrefabInstances;

    [DisableInPrefabs]
    public GameObject DisabledInPrefabs;

    [DisableInNonPrefabs]
    public GameObject DisabledInNonPrefabs;
}
