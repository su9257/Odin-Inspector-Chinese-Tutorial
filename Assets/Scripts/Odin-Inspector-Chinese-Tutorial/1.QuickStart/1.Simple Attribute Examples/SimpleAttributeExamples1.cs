using UnityEngine;

using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace D_Game.Demo
{
    public class SimpleAttributeExamples1 : MonoBehaviour
    {
        [HideInInspector]
        public int NormallyVisible;

        [ShowInInspector]
        private bool normallyHidden;

        [ShowInInspector, PropertyOrder(-2)]
        //[ShowInInspector]
        public ScriptableObject Property { get; set; }


        [Title("Assets only")]
        [AssetsOnly]
        public List<GameObject> OnlyPrefabs;

        [AssetsOnly]
        public GameObject SomePrefab;

        [AssetsOnly]
        public Material MaterialAsset;

        [AssetsOnly]
        public MeshRenderer SomeMeshRendererOnPrefab;

        [Title("Scene Objects only")]
        [SceneObjectsOnly]
        public List<GameObject> OnlySceneObjects;

        [SceneObjectsOnly]
        public GameObject SomeSceneObject;

        [SceneObjectsOnly]
        public MeshRenderer SomeMeshRenderer;
    }
}

