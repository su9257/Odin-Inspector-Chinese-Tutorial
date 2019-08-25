using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailedInfoBoxExample : MonoBehaviour
{
    [DetailedInfoBox("详情请点击...",
        "菜鸟海澜：下面是详细信息，这个欢迎大家留言指正，对应的工程已经上传Github，" +
        "地址为：https://github.com/su9257/Odin-Inspector-Chinese-Tutorial")]
    public string message= "无";
}
