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

    [Title("有条件的信息框")]
    public  bool ToggleInfoBoxes;

    [InfoBox("This info box is only shown while in editor mode.", InfoMessageType.Error, "IsInEditMode")]
    public float G;
    private static bool IsInEditMode()
    {
        return !Application.isPlaying;
    }

    [InfoBox("此信息框可由静态字段隐藏.", "ToggleInfoBoxes")]
    public float E;

    [InfoBox("此信息框可由静态字段隐藏.", "ToggleInfoBoxes")]
    public float F;

    [InfoBox("$InfoBoxMessage")]
    [InfoBox("@\"Time: \" + DateTime.Now.ToString(\"HH:mm:ss\")")]
    public string InfoBoxMessage = "My dynamic info box message";
}