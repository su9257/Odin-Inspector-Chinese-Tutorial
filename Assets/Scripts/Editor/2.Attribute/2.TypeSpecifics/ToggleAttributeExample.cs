using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class ToggleAttributeExample : MonoBehaviour
{
    [Toggle("Enabled")]
    public MyToggleable Toggler = new MyToggleable();

    public ToggleableClass Toggleable = new ToggleableClass();

    [Serializable]
    public class MyToggleable
    {
        public bool Enabled;
        public int MyValue;
    }

    // 您还可以直接在类定义上使用Toggle属性。
    [Serializable, Toggle("Enabled")]
    public class ToggleableClass
    {
        public bool Enabled;
        public string Text;
    }
}