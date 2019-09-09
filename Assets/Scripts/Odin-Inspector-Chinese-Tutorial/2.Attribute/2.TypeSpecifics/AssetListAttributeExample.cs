using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;


public class AssetListAttributeExample : MonoBehaviour
{
    [AssetList]
    [PreviewField(70, ObjectFieldAlignment.Center)]
    public Texture2D SingleObject;

    [AssetList(Path = "/Plugins/Sirenix/")]
    public List<ScriptableObject> AssetList;

    [FoldoutGroup("过滤后的AssetLists",Expanded = true)]
    [AssetList(Path = "Plugins/Sirenix/")]
    public UnityEngine.Object Object;

    [AssetList(AutoPopulate = true)]//设置为true则自动填充符合规则的资源,false为只显示不填充
    [FoldoutGroup("过滤后的AssetLists")]
    public List<MeshRenderer> AutoPopulatedWhenInspected;

    [AssetList(LayerNames = "MyLayerName")]//
    [FoldoutGroup("过滤后的AssetLists")]
    public GameObject[] AllPrefabsWithLayerName;

    [AssetList(AssetNamePrefix = "前缀")]
    [FoldoutGroup("过滤后的AssetLists")]
    public List<GameObject> PrefabsStartingWithPrefix;

    [FoldoutGroup("过滤后的AssetLists")]
    [AssetList(Tags = "TagA, TabB",Path = "/Build/")]
    public List<GameObject> GameObjectsWithTag;

    [FoldoutGroup("过滤后的AssetLists")]
    [AssetList(CustomFilterMethod = "HasRigidbodyComponent")]
    public List<GameObject> MyRigidbodyPrefabs;

    private bool HasRigidbodyComponent(GameObject obj)
    {
        return obj.GetComponent<Rigidbody>() != null;
    }

}

