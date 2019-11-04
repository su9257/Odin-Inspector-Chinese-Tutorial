using UnityEngine;
using Sirenix.OdinInspector;


namespace D_Game.Demo
{
    public class ChangingTheOrderOfProperties1 : MonoBehaviour
    {
        [PropertyOrder(2)]
        public int Second;

        [Button]
        [PropertyOrder(1)]
        public void First()
        {
            // ...
        }
    }
}

