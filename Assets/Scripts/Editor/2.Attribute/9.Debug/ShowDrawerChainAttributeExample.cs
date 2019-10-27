using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Utilities;
using Sirenix.OdinValidator;
using Sirenix.Serialization;

public class ShowDrawerChainAttributeExample : MonoBehaviour
{
#if UNITY_EDITOR
    [HorizontalGroup(PaddingRight = -1)]
    [ShowInInspector, PropertyOrder(-1)]
    public bool ToggleHideIf { get { Sirenix.Utilities.Editor.GUIHelper.RequestRepaint(); return UnityEditor.EditorApplication.timeSinceStartup % 3 < 1.5f; } }
    [HorizontalGroup]
    [ShowInInspector, ProgressBar(0, 1.5f)]
    private double Animate { get { return Math.Abs(UnityEditor.EditorApplication.timeSinceStartup % 3 - 1.5f); } }
#endif

    [InfoBox(
        "Any drawer not used in the draw chain will be greyed out in the drawer chain so that you can more easily debug the draw chain. You can see this by toggling the above toggle field.\n\n" +
        "If you have any custom drawers they will show up with green names in the drawer chain.")]
    [ShowDrawerChain]
    [HideIf("ToggleHideIf")]
    public GameObject SomeObject;

    [Range(0, 10)]
    [ShowDrawerChain]
    public float SomeRange;
}
