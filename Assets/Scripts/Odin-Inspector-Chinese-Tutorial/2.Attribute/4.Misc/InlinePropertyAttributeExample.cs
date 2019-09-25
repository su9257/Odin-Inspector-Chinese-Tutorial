using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlinePropertyAttributeExample : MonoBehaviour
{
    public Vector3 Vector3;

    public Vector3Int MyVector3Int;

    [InlineProperty(LabelWidth = 13)]
    public Vector2Int MyVector2Int;

    [Serializable]
    [InlineProperty(LabelWidth = 13)]
    public struct Vector3Int
    {
        [HorizontalGroup]
        public int X;

        [HorizontalGroup]
        public int Y;

        [HorizontalGroup]
        public int Z;
    }

    [Serializable]
    public struct Vector2Int
    {
        [HorizontalGroup]
        public int X;

        [HorizontalGroup]
        public int Y;
    }
}
