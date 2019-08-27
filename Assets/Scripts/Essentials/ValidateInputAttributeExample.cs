using Sirenix.OdinInspector;
using UnityEngine;



namespace D_Game.Demo
{
    public class ValidateInputAttributeExample : MonoBehaviour
    {
        [HideLabel]
        [ValidateInput("MustBeNull", "这个字段应该为空。")]
        public MyScripty DefaultMessage;

        [ValidateInput("CheckGameObject", "这个物体不应该为空。")]
        public GameObject tempObj = null;

        [Space(12), HideLabel]
        [ValidateInput("HasMeshRendererDynamicMessage", "aaaaaaaaaaaaaaa")]
        public GameObject DynamicMessage;

        [Space(12), HideLabel]
        [Title("Dynamic message type", "The validation method can also control the type of the message")]
        [ValidateInput("HasMeshRendererDynamicMessageAndType", "预制件必须有一个MeshRenderer组件")]
        public GameObject DynamicMessageAndType;

        [Space(8), HideLabel]
        [InfoBox("Change GameObject value to update message type", InfoMessageType.None)]
        public InfoMessageType MessageType;

        [Space(12), HideLabel]
        [Title("Dynamic default message", "Use $ to indicate a member string as default message")]
        [ValidateInput("AlwaysFalse", "$Message", InfoMessageType.Warning)]
        public string Message = "Dynamic ValidateInput message";

        private bool AlwaysFalse(string value)
        {
            return false;
        }

        private bool MustBeNull(MyScripty scripty)
        {
            return scripty == null;
        }

        private bool CheckGameObject(GameObject tempObj)
        {
            return tempObj != null;
        }

        private bool HasMeshRendererDefaultMessage(GameObject gameObject)
        {
            if (gameObject == null) return true;

            return gameObject.GetComponentInChildren<MeshRenderer>() != null;
        }

        private bool HasMeshRendererDynamicMessage(GameObject gameObject, ref string errorMessage)
        {
            if (gameObject == null) return true;

            if (gameObject.GetComponentInChildren<MeshRenderer>() == null)
            {
                // If errorMessage is left as null, the default error message from the attribute will be used
                errorMessage = "\"" + gameObject.name + "\" must have a MeshRenderer component";
                return false;
            }

            return true;
        }

        private bool HasMeshRendererDynamicMessageAndType(GameObject gameObject, ref string errorMessage, ref InfoMessageType? messageType)
        {
            if (gameObject == null) return true;

            if (gameObject.GetComponentInChildren<MeshRenderer>() == null)
            {
                // If errorMessage is left as null, the default error message from the attribute will be used
                errorMessage = "\"" + gameObject.name + "\" should have a MeshRenderer component";

                // If messageType is left as null, the default message type from the attribute will be used
                messageType = this.MessageType;

                return false;
            }

            return true;
        }

        public class MyScripty : ScriptableObject
        {

        }
    }
}

