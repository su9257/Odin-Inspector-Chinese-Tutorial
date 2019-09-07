using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomValueDrawerExample : MonoBehaviour
{
    public float From = -10, To = 10;

    [CustomValueDrawer("MyStaticCustomDrawerStatic")]
    public float CustomDrawerStatic;

    [CustomValueDrawer("MyStaticCustomDrawerInstance")]
    public float CustomDrawerInstance;

    [CustomValueDrawer("MyStaticCustomDrawerArray")]
    public float[] CustomDrawerArray = new float[] { 3f, 5f, 6f };

    [CustomValueDrawer("MyCustomNameDrawerStatic")]
    public string CustomName;

    private static float MyStaticCustomDrawerStatic(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, 0f, 10f);
    }

    private float MyStaticCustomDrawerInstance(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(label, value, this.From, this.To);
    }

    private float MyStaticCustomDrawerArray(float value, GUIContent label)
    {
        return EditorGUILayout.Slider(value, this.From, this.To);
    }

    public string MyCustomNameDrawerStatic(string tempName, GUIContent label)
    {
        return EditorGUILayout.TextField(label, tempName);
    }
}
