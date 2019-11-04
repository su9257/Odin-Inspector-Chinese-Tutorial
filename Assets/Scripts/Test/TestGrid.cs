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
using UnityEngine.UI;

public class TestGrid : MonoBehaviour
{
    // Start is called before the first frame update
    [ChildGameObjectsOnly]
    public GridLayoutGroup gridLayout;
    void Start()
    {
        
    }
    [Button(ButtonSizes.Large)]
    public void CreatAsset()
    {
        TestExampleHelper.GetScriptableObject<TestMyScripty>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gridLayout.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gridLayout.enabled = true;
        }
    }
}
