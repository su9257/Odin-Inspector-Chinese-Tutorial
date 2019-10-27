using UnityEngine;
using Sirenix.OdinInspector;


namespace D_Game.Demo
{
    public class AttributeExpressions2 : MonoBehaviour
    {
        [ShowIf("@this.someNumber >= 0f && this.someNumber <= 10f")]
        public string myStrNumber;

        public float someNumber;
    }
}

