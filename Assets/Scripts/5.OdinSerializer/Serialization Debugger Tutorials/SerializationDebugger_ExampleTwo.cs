using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;

public class SerializationDebugger_ExampleTwo : SerializedMonoBehaviour
{
    public string UnityString = "Unity_菜鸟海澜";

    [OdinSerialize]
    public string OdinAndUnityString = "OdinAndUnity_菜鸟海澜";
    [OdinSerialize][NonSerialized]
    public string OdinString = "Odin_菜鸟海澜";

    public List<TempOdinSerializationData> OdinList = new List<TempOdinSerializationData>();

    [SerializeField]
    public TempUnitySerializationData tempUnitySerializationData = new TempUnitySerializationData();

    public TempOdinSerializationData tempOdinSerializationData = new TempOdinSerializationData();

    public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
    void Start()
    {

    }
}
