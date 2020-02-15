using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;

public class SerializationDebugger_ExampleOne : MonoBehaviour
{

    public string UnityString = "Unity_菜鸟海澜";
    public List<string> UnityStringList = new List<string>();

    [NonSerialized][OdinSerialize]
    public string OdinStringInvalid= "错误序列化";

    public TempUnitySerializationData tempUnitySerializationData = new TempUnitySerializationData();
    public TempOdinSerializationData tempOdinSerializationData = new TempOdinSerializationData();

    public List<TempUnitySerializationData> UnityList = new List<TempUnitySerializationData>();

    public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

    void Start()
    {

    }

}
[Serializable]
public class TempUnitySerializationData
{
    public string UnityString = "菜鸟海澜";

}


public class TempOdinSerializationData
{
    public string UnityString = "菜鸟海澜";
}