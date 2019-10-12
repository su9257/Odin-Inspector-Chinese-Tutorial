using Sirenix.OdinInspector;
using UnityEngine;

public class DisableInNonPrefabsAttributeExample : MonoBehaviour
{
    [InfoBox("这些属性只有在检查GameObject的组件时才会起作用。")]

    [DisableInNonPrefabs] // 当不是预制体是灰态此属性
    public GameObject DisabledInNonPrefabs;
}
