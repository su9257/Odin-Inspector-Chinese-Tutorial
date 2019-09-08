using Sirenix.OdinInspector;
using UnityEngine;

public class ShowInInspectorExample : MonoBehaviour
{
    [ShowInInspector]
    private int myPrivateInt = 0;

    [ShowInInspector]
    public int MyPropertyInt { get; set; }

    [ShowInInspector]
    public int ReadOnlyProperty
    {
        get { return this.myPrivateInt; }
    }

    [ShowInInspector]
    public static bool StaticProperty { get; set; }

    private void Start()
    {
        Debug.Log($"MyPropertyInt：{MyPropertyInt}");
        Debug.Log($"EvenNumber：{EvenNumber}");
    }

    [SerializeField, HideInInspector]
    private int evenNumber;

    [ShowInInspector]
    public int EvenNumber
    {
        get { return this.evenNumber; }
        set { this.evenNumber = value + value % 2; }
    }

}
