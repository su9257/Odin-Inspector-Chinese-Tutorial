using Sirenix.OdinInspector;
using UnityEngine;

public class HideLabelExample : MonoBehaviour
{
    public string showLabel = "菜鸟海澜";

    [HideLabel]
    public string hideLabel = "隐藏标题";

    [ShowInInspector]
    public string ShowPropertyLabel { get; set; }

    [HideLabel][ShowInInspector]
    public string HidePropertyLabel { get; set; }
}
