using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


[ShowOdinSerializedPropertiesInInspector]
public class CustomSerializedScriptableObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField, HideInInspector]
    private SerializationData serializationData;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        UnitySerializationUtility.DeserializeUnityObject(this, ref this.serializationData);
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        UnitySerializationUtility.SerializeUnityObject(this, ref this.serializationData);
    }
}


