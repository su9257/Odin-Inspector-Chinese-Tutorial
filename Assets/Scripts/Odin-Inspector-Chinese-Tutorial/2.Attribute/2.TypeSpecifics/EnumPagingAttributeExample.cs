using Sirenix.OdinInspector;
using UnityEngine;



public class EnumPagingAttributeExample : MonoBehaviour
{
    [EnumPaging]
    public SomeEnum SomeEnumField;

    public enum SomeEnum
    {
        A, B, C
    }

#pragma warning disable CS0649
    [ShowInInspector]
    [EnumPaging, OnValueChanged("SetCurrentTool")]
    [InfoBox("Changing this property will change the current selected tool in the Unity editor.")]
    private UnityEditor.Tool sceneTool;
#pragma warning restore CS0649
    private void SetCurrentTool()
    {
        UnityEditor.Tools.current = this.sceneTool;
    }
}