using Sirenix.OdinInspector;
using UnityEngine;

public class DisableInPrefabInstancesAttributeExample : MonoBehaviour
{
    [DisableInPrefabInstances]//在hierarchy中为预制体时则禁用此属性
    public GameObject DisabledInPrefabInstances;
}
