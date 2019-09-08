using Sirenix.OdinInspector;
using UnityEngine;


public class ValidateInputAttributeExample : MonoBehaviour
{

    [ValidateInput("MustBeNull", "这个字段应该为空。")]
    public MyScripty DefaultMessage;
    private bool MustBeNull(MyScripty scripty)
    {
        return scripty == null;
    }

    [ReadOnly]
    public string dynamicMessage = "这个物体不应该为空！";
    [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.None)]
    public GameObject targetObj_None = null;
    [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.Info)]
    public GameObject targetObj_Info = null;
    [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.Warning)]
    public GameObject targetObj_Warning = null;
    [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.Error)]
    public GameObject targetObj_Error = null;

    private bool CheckGameObject(GameObject tempObj)
    {
        return tempObj != null;
    }

    [ValidateInput("IfNullIsFalse", "$Message", InfoMessageType.Warning)]
    public string Message = "Dynamic ValidateInput message";

    private bool IfNullIsFalse(string value)
    {
        return string.IsNullOrEmpty(value);
    }

    [ValidateInput("HasMeshRendererDynamicMessage", "对应的函数中已经有消息，所以这个默认消息已经没用")]
    public GameObject DynamicMessage;
    private bool HasMeshRendererDynamicMessage(GameObject gameObject, ref string errorMessage)
    {
        if (gameObject == null) return true;

        if (gameObject.GetComponentInChildren<MeshRenderer>() == null)
        {
            errorMessage = "\"" + gameObject.name + "\" 这玩应必须有一个 MeshRenderer 组件";//如果设置消息，则默认消息会被覆盖
            return false;
        }
        return true;
    }

    [ValidateInput("HasMeshRendererDynamicMessageAndType", "对应的函数中已经有消息和类型，所以这个默认消息和类型已经没用")]
    public GameObject DynamicMessageAndType;

    [InfoBox("Change GameObject value to update message type", InfoMessageType.Info)]
    public InfoMessageType MessageType;
    private bool HasMeshRendererDynamicMessageAndType(GameObject gameObject, ref string errorMessage, ref InfoMessageType? messageType)
    {
        if (gameObject == null) return true;

        if (gameObject.GetComponentInChildren<MeshRenderer>() == null)
        {
            errorMessage = "\"" + gameObject.name + "\" 要有一个 MeshRenderer 组件";//如果设置消息，则默认消息会被覆盖
            messageType = this.MessageType;//如果设置消息类型，则默认消息类型会被覆盖
            return false;
        }
        return true;
    }


    private bool HasMeshRendererDefaultMessage(GameObject gameObject)
    {
        if (gameObject == null) return true;
        return gameObject.GetComponentInChildren<MeshRenderer>() != null;
    }
}