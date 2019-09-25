using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxAttributeExample : MonoBehaviour
{
    [Title("InfoBox message types")]
    [InfoBox("Default info box.")]
    public int A;

    [InfoBox("Warning info box.", InfoMessageType.Warning)]
    public int B;

    [InfoBox("Error info box.", InfoMessageType.Error)]
    public int C;

    [InfoBox("Info box without an icon.", InfoMessageType.None)]
    public int D;

    [Title("Conditional info boxes")]
    public bool ToggleInfoBoxes;

    [InfoBox("This info box is only shown while in editor mode.", InfoMessageType.Error, "IsInEditMode")]
    public float G;

    [InfoBox("This info box is hideable by a static field.", "ToggleInfoBoxes")]
    public float E;

    [InfoBox("This info box is hideable by a static field.", "ToggleInfoBoxes")]
    public float F;

    [Title("Info box member reference and attribute expressions")]
    [InfoBox("$InfoBoxMessage")]
    [InfoBox("@\"Time: \" + DateTime.Now.ToString(\"HH:mm:ss\")")]
    public string InfoBoxMessage = "My dynamic info box message";

    private static bool IsInEditMode()
    {
        return !Application.isPlaying;
    }
}
