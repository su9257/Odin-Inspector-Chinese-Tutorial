using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInspectorGUIAttributeExample : MonoBehaviour
{
    //[OnInspectorGUI("DrawPreview", append: true)]
    //public Texture2D Texture = EditorIcons.OdinInspectorLogo;

    [OnInspectorGUI("DrawPreview", append: true)]
    public Texture2D Texture;
    private void DrawPreview()
    {
        if (this.Texture == null) return;

        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label(this.Texture);
        GUILayout.EndVertical();
    }

    [OnInspectorGUI]
    private void OnInspectorGUI()
    {
        UnityEditor.EditorGUILayout.HelpBox("OnInspectorGUI can also be used on both methods and properties", UnityEditor.MessageType.Info);
    }
}
