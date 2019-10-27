using Sirenix.OdinInspector;
using UnityEngine;

public class InlineEditorAttributeExample : MonoBehaviour
{
    [Title("Boxed / Default")]
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    public TestExampleTransform Boxed;

    [Title("Foldout")]
    [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
    public TestExampleTransform Foldout;

    [Title("Hide ObjectField")]
    [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
    public TestExampleTransform CompletelyHidden;

    [Title("Show ObjectField if null")]
    [ShowInInspector]
    [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
    public TestExampleTransform OnlyHiddenWhenNotNull;

    [InlineEditor]
    public TestExampleTransform InlineComponent ;

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