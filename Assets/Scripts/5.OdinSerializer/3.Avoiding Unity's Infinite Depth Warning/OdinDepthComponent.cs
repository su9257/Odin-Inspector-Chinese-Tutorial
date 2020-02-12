using Sirenix.Serialization;
using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class OdinDepthComponent : SerializedMonoBehaviour
{
    [NonSerialized, OdinSerialize]
    public OdinNodeB OdinNodeB;
}

public class OdinNodeA
{
    public OdinNodeB cycle;
}

public class OdinNodeB: OdinNodeA
{

}

