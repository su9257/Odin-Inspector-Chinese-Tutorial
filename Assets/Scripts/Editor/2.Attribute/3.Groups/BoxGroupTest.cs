using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BoxGroupTest : MonoBehaviour
{

    [BoxGroup]
    public int boxint;
    [BoxGroup]
    public string boxstring;

    [BoxGroup("Group")]
    public int boxint1;
    [BoxGroup("Group")]
    public string boxstring1;

    [BoxGroup("Group/Group2")]
    public int boxint2;
    [BoxGroup("Group/2")]
    public string boxstring2;
    [BoxGroup("Group/Group2")]
    public int boxint2_1;
    [BoxGroup("Group/Group2/1")]
    public int boxint20000_123;
    [BoxGroup("Group/Group2/1/1",ShowLabel =true,CenterLabel = true)]
    public int boxint2_123;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
