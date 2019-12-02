using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;


public class ExampleOdinSerializedScript : SerializedMonoBehaviour
{
    // 使用Odin序列化，而非Unity序列化
    public Dictionary<int, string> firstDictionary= new Dictionary<int, string>();

    // MyClassByUnity 因为标记为 Serializable ,所以使用Unity 自带的序列化，而非Odin 序列化
    public MyClassByUnity myUnityReference = new MyClassByUnity();

    //强制使用 Odin 序列化，而不使用Unity的序列化
    [NonSerialized, OdinSerialize]
    public MyClassByOdin myOdinReference = new MyClassByOdin();

    private void Start()
    {
        Debug.Log(firstDictionary.Count);
        Debug.Log(myUnityReference.secondDictionary_Unity.Count);
        Debug.Log(myOdinReference.secondDictionary_Odin.Count);
    }
    
}

[Serializable]
public class MyClassByUnity
{
    // 虽然标记为 OdinSerialize 特性, 但是依然不会被序列化
    [OdinSerialize]
    public Dictionary<int, string> secondDictionary_Unity = new Dictionary<int, string>();
}

[Serializable]
public class MyClassByOdin
{
    [OdinSerialize]
    [NonSerialized]
    public Dictionary<int, string> secondDictionary_Odin= new Dictionary<int, string>();
}
