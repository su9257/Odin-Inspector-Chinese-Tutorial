using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldoutGroupAttributeExample : MonoBehaviour
{
    [FoldoutGroup("Group 1")]
    public int A;

    [FoldoutGroup("Group 1")]
    public int B;

    [FoldoutGroup("Group 1")]
    public int C;

    [FoldoutGroup("Collapsed group", expanded: false)]
    public int D;

    [FoldoutGroup("Collapsed group")]
    public int E;

    [FoldoutGroup("$GroupTitle", expanded: true)]
    public int One;

    [FoldoutGroup("$GroupTitle")]
    public int Two;
    [FoldoutGroup("$GroupTitle")]
    public int Three;


    public string GroupTitle = "Dynamic group title";
}
