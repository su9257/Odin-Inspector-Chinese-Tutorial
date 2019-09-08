using Sirenix.OdinInspector;
using UnityEngine;

public class RequiredExample : MonoBehaviour
{
    [Required]
    public GameObject MyGameObject;

    [Required("自定义错误消息.")]
    public Rigidbody MyRigidbody;


    public string DynamicMessage = "Dynamic Message";
    [Required("$DynamicMessage")]
    public GameObject GameObject_DynamicMessage;

    [Required("$ReturnStringFunction")]
    public GameObject GameObject_DynamicMessage1;
    public string ReturnStringFunction()
    {
        return "菜鸟海澜";
    }

    [Required("$DynamicMessage", InfoMessageType.None)]
    public GameObject GameObject_None;
    [Required("$DynamicMessage", InfoMessageType.Info)]
    public GameObject GameObject_Info;
    [Required("$DynamicMessage", InfoMessageType.Warning)]
    public GameObject GameObject_Warning;
    [Required("$DynamicMessage",InfoMessageType.Error)]
    public GameObject GameObject_Error;
}
