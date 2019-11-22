using Sirenix.OdinInspector;
using UnityEngine;

public class TestCustomComponent : MonoBehaviour
{
    [Required("需要一个Obj", MessageType = InfoMessageType.Warning)]
    public GameObject tempObj;

    public enum CustomType
    {
        Node,One,Two
    }
    [TestValidatorAttribute]
    public CustomType customType = CustomType.Node;
}