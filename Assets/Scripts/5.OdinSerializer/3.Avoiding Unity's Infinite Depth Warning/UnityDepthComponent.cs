using System;
using UnityEngine;


public class UnityDepthComponent : MonoBehaviour
{
    public UnityNodeB unityNodeB;
}

[Serializable]
public class UnityNodeA
{
    public UnityNodeB cycle;
}

[Serializable]
public class UnityNodeB : UnityNodeA
{

}

