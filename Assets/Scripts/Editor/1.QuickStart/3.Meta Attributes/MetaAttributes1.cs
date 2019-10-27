using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace D_Game.Demo
{
    public class MetaAttributes1 : MonoBehaviour
    {
        [Required]
        public GameObject RequiredReference;

        [InfoBox("此消息仅在MyInt字段为偶数时显示", "IsEven")]
        public int MyInt;

        private bool IsEven()
        {
            return this.MyInt % 2 == 0;
        }
    }
}

