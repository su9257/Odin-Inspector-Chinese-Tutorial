using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HideMonoScript_ScriptableObject", menuName = "CreatScriptableObject/HideMonoScript")]
[HideMonoScript]
public class TestHideMonoScript : ScriptableObject
{
    public string Value;
}
