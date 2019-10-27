using UnityEngine;
using Sirenix.OdinInspector;


namespace D_Game.Demo
{
    public class ChangingTheOrderOfProperties0 : MonoBehaviour
    {
        [PropertyOrder(1)]
        public int Last;

        [PropertyOrder(-1)]
        public int First;

        // All properties default to 0.
        public int Middle;
    }
}

