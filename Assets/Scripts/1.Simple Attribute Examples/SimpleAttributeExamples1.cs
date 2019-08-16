using UnityEngine;

using Sirenix.OdinInspector;

namespace D_Game.Demo
{
    public class SimpleAttributeExamples1 : MonoBehaviour
    {
        [HideInInspector]
        public int NormallyVisible;

        [ShowInInspector]
        private bool normallyHidden;

        [ShowInInspector]
        public ScriptableObject Property { get; set; }
    }
}

