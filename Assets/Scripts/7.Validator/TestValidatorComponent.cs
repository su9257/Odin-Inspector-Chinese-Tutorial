using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using TMPro;
using Sirenix.OdinInspector;

public class TestValidatorComponent : MonoBehaviour
{
    [Required("需要一个Obj", MessageType = InfoMessageType.Warning)]
    public GameObject tempObj;
    void Start()
    {

    }


}


