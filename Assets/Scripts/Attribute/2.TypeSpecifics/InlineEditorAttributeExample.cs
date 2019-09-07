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
    //ExampleHelper.GetMaterial(),
    //ExampleHelper.GetMaterial(),
    //ExampleHelper.GetMaterial(),
    };

    [InlineEditor(InlineEditorModes.LargePreview)]
    public Mesh InlineMeshPreview ;

    // You can also use the InlineEditor attribute directly on a class definition itself.
    //[InlineEditor]
    public class ExampleTransform : ScriptableObject
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale = Vector3.one;
    }


    private void Start()
    {
        Boxed = ExampleHelper.GetScriptableObject<ExampleTransform>();
        Foldout = ExampleHelper.GetScriptableObject<ExampleTransform>();
        CompletelyHidden = ExampleHelper.GetScriptableObject<ExampleTransform>();
        OnlyHiddenWhenNotNull = ExampleHelper.GetScriptableObject<ExampleTransform>();
    }
}

