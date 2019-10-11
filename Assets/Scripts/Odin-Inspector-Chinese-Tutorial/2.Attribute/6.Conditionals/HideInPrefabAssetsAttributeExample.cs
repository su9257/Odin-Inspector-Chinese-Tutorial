using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInPrefabAssetsAttributeExample : MonoBehaviour
{
    [HideInPrefabAssets] //在Asset中且是预制体时隐藏
    public GameObject HiddenInPrefabAssets;
}
