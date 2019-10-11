using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInPrefabAssetsAttributeExample : MonoBehaviour
{
    [DisableInPrefabAssets]//在asset中且为预制体时，这个属性被警用
    public GameObject DisabledInPrefabAssets;
}
