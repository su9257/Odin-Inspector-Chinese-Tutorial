using Sirenix.OdinInspector;
using UnityEngine;

public class DelayedPropertyExample : MonoBehaviour
{

    [OnValueChanged("ValueChangeCallBack")]
    public int field;
    //但是，正如名称所示，DelayedProperty应用于属性。
    [ShowInInspector]
    [OnValueChanged("ValueChangeCallBack")]
    public string property { get; set; }


    // 延迟和延迟属性实际上是相同的
    [Delayed]
    [OnValueChanged ("ValueChangeCallBack")]
    public int delayedField;

    //但是，正如名称所示，DelayedProperty应用于属性。
    [ShowInInspector, DelayedProperty]
    [OnValueChanged("ValueChangeCallBack")]
    public string delayedProperty { get; set; }

    public void ValueChangeCallBack()
    {
        Debug.Log("数值有变化");
    }
}
