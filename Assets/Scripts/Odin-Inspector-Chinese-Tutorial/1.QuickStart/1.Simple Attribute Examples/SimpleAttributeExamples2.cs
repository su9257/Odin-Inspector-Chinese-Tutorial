using UnityEngine;

using Sirenix.OdinInspector;
using System;

namespace D_Game.Demo
{
    public class SimpleAttributeExamples2 : MonoBehaviour
    {
        [PreviewField, Required, AssetsOnly]
        public GameObject Prefab;

        [ShowInInspector,HideLabel, Required, PropertyOrder(-5)]
        public string Name { get; set; }
        [ShowInInspector, HideLabel, Required, PropertyOrder(-6)]
        public string EmptyName { get; private set; }

        [Button(ButtonSizes.Medium), PropertyOrder(-3)]
        public void RandomName()
        {
            this.Name = Guid.NewGuid().ToString();
        }
    }
}

