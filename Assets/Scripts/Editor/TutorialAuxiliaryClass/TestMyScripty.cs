using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(fileName = "MyScripty_ScriptableObject", menuName = "CreatScriptableObject/MyScripty")]
[TypeInfoBox("TypeInfoBox 特性 能以文本的形式显示在顶端 。例如, MonoBehaviours or ScriptableObjects.")]
public class TestMyScripty : ScriptableObject
{
    public string MyText = TestExampleHelper.GetString();
    [TextArea(10, 15)]
    public string Box;

    [Button(ButtonSizes.Large)]
    public void TestInvoke()
    {
        
    }
}

