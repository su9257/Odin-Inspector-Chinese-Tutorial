using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedPropertyExample : MonoBehaviour
{
    // 延迟和延迟属性实际上是相同的…
    [Delayed]
    [OnValueChanged ("ValueChangeCallBack")]
    public int DelayedField;

    // ...但是，正如名称所示，DelayedProperty应用于属性。
    [ShowInInspector, DelayedProperty]
    [OnValueChanged("ValueChangeCallBack")]
    public string DelayedProperty { get; set; }

    public void ValueChangeCallBack()
    {
        Debug.Log("数值有变化");
    }
}
