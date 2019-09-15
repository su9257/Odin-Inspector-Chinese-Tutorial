using Sirenix.OdinInspector;
using UnityEngine;

public class InlineEditorAttributeExample : MonoBehaviour
{
    [Title("Boxed / Default")]
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    public ExampleTransform Boxed;

    [Title("Foldout")]
    [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
    public ExampleTransform Foldout;

    [Title("Hide ObjectField")]
    [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
    public ExampleTransform CompletelyHidden;

    [Title("Show ObjectField if null")]
    [ShowInInspector]
    [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
    public ExampleTransform OnlyHiddenWhenNotNull;

    [InlineEditor]
    public ExampleTransform InlineComponent ;

    [InlineEditor(InlineEditorModes.FullEditor)]
    public Material FullInlineEditor;

    [InlineEditor(InlineEditorModes.GUIAndHeader)]
    public Material InlineMaterial ;

    [InlineEditor(InlineEditorModes.SmallPreview)]
    public Material[] InlineMaterialList = new Material[]
    {
    };

    [InlineEditor(InlineEditorModes.LargePreview)]
    public Mesh InlineMeshPreview ;

}