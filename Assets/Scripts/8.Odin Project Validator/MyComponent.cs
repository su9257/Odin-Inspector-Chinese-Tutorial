using Sirenix.OdinInspector;
using UnityEngine;



namespace D_Game.Demo
{
    public class MyComponent : MonoBehaviour
    {
        [Required]
        public string Name;

        [AssetsOnly, AssetSelector, Required]
        public GameObject Prefab;

        [ChildGameObjectsOnly, Required]
        public GameObject Child;

        [ValidateInput("@OddNumber % 2 == 1", "@OddNumber + \" is too normal!\"")]
        public int OddNumber;
    }
}

