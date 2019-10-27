using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;


public class ExampleOdinSerializedScript : SerializedMonoBehaviour
{
    // Unity will not serialize. Serialized by Odin.
    public Dictionary<int, string> FirstDictionary= new Dictionary<int, string>();

    // Unity will serialize. NOT serialized by Odin.
    public MyClassByUnity MyUnityReference = new MyClassByUnity();

    [NonSerialized, OdinSerialize]
    public MyClassByOdin MyOdinReference = new MyClassByOdin();

    private void Start()
    {
        Debug.Log(FirstDictionary.Count);
        Debug.Log(MyUnityReference.SecondDictionary.Count);
        Debug.Log(MyOdinReference.SecondDictionary.Count);
    }
}

[Serializable]
public class MyClassByUnity
{
    // Despite the OdinSerialize attribute, this field is not serialized.
    [OdinSerialize]
    public Dictionary<int, string> SecondDictionary = new Dictionary<int, string>();
}

[Serializable]
public class MyClassByOdin
{
    // Despite the OdinSerialize attribute, this field is not serialized.
    [OdinSerialize]
    public Dictionary<int, string> SecondDictionary= new Dictionary<int, string>();
}


