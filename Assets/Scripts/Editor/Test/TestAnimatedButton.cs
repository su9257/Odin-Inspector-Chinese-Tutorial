using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.OdinValidator;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TestAnimatedButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnimatedButton animatedButton = GetComponent<AnimatedButton>();
        animatedButton.onClick.AddListener(() => { Debug.Log("TestAnimatedButton"); });
    }

}
