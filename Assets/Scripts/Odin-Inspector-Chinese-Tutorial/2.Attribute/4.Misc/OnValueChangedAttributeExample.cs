using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValueChangedAttributeExample : MonoBehaviour
{

    [ShowInInspector]
    [EnumPaging, OnValueChanged("SetCurrentTool")]
    [InfoBox("Changing this property will change the current selected tool in the Unity editor.")]
    private UnityEditor.Tool sceneTool;

    private void SetCurrentTool()
    {
        UnityEditor.Tools.current = this.sceneTool;
    }

    [OnValueChanged("CreateMaterial")]
    public Shader Shader;

    [ReadOnly, InlineEditor(InlineEditorModes.LargePreview)]
    public Material Material;

    private void CreateMaterial()
    {
        if (this.Material != null)
        {
            Material.DestroyImmediate(this.Material);
        }

        if (this.Shader != null)
        {
            this.Material = new Material(this.Shader);
        }
    }
}
