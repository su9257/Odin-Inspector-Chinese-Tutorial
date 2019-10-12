using Sirenix.OdinInspector;
using UnityEngine;

public class DisableInPrefabAssetsAttributeExample : MonoBehaviour
{
    [DisableInPrefabAssets]//在asset中且为预制体时，这个属性被警用
    public GameObject DisabledInPrefabAssets;
}
