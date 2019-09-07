using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGUIExample : MonoBehaviour
{
    [ShowInInspector]
    public int GUIDisabledProperty { get { return 10; } }

    [ShowInInspector, EnableGUI]
    public int GUIEnabledProperty { get { return 10; } }
}
