using UnityEngine;
using Sirenix.OdinInspector;

public class ChildGameObjectsOnlyAttributeExample : MonoBehaviour
    {
    [ChildGameObjectsOnly(IncludeSelf = false)]//是否包含顶层定节点
    public Transform ChildOrSelfTransform;

    [ChildGameObjectsOnly]
    public GameObject ChildGameObject;

    [ChildGameObjectsOnly(IncludeSelf = false)]
    public Light[] Lights;

    public void Start()
    {
        Debug.Log(ChildOrSelfTransform);
        Debug.Log(ChildGameObject);
    }
}