using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredExample : MonoBehaviour
{
    [Required]
    public GameObject MyGameObject;

    [Required("自定义错误消息.")]
    public Rigidbody MyRigidbody;

    [InfoBox("使用$将成员字符串表示为消息.")]
    [Required("$DynamicMessage")]
    public GameObject GameObject;

    public string DynamicMessage = "Dynamic error message";
}
