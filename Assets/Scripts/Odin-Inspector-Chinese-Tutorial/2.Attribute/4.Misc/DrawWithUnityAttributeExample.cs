using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithUnityAttributeExample : MonoBehaviour
{

    [InfoBox("If you ever experience trouble with one of Odin's attributes, there is a good chance that the DrawWithUnity will come in handy.")]
    public GameObject ObjectDrawnWithOdin;

    [DrawWithUnity]
    public GameObject ObjectDrawnWithUnity;
}
