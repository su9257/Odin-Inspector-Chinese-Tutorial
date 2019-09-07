using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsOnlyExample : MonoBehaviour
{
    [AssetsOnly]
    public List<GameObject> assetsOnlyPrefabList;

    [AssetsOnly]
    public GameObject ssetsOnlyPrefab;

    [AssetsOnly]
    public Material assetsOnlyMaterial;

    [AssetsOnly]
    public MeshRenderer someMeshRendererOnPrefab;

    [SceneObjectsOnly]
    public List<GameObject> onlySceneObjectList;

    [SceneObjectsOnly]
    public GameObject someSceneObject;

    [SceneObjectsOnly]
    public MeshRenderer someMeshRendererInScene;
}
