using UnityEngine;
using Sirenix.OdinInspector;


namespace D_Game.Demo
{
    public class MetaAttributes0 : MonoBehaviour
    {

        /// <summary>
        /// 验证特性 填入对应监测函数的名称
        /// </summary>
        [ValidateInput("IsValid")]
        public int GreaterThanZero;

        private bool IsValid(int value)
        {
            return value > 0;
        }
       

        [OnValueChanged("UpdateRigidbodyReference")]
        public GameObject Prefab;

        [ShowInInspector,Required,HideLabel]
        private Rigidbody prefabRigidbody;

        private void UpdateRigidbodyReference()
        {
            if (this.Prefab != null)
            {
                this.prefabRigidbody = this.Prefab.GetComponent<Rigidbody>();
            }
            else
            {
                this.prefabRigidbody = null;
            }
        }
    }
}

