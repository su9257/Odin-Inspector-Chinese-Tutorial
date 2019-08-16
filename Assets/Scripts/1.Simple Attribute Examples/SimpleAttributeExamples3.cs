using UnityEngine;

using Sirenix.OdinInspector;
using System;

namespace D_Game.Demo
{
    public class SimpleAttributeExamples3 : MonoBehaviour
    {
        /// <summary>
        /// 其中Width为对应这个组的范围(100*100 )PreviewField为这个填充标签的范围
        /// </summary>
        [HorizontalGroup("Split", Width = 100), HideLabel, PreviewField(80)]
        public Texture2D Icon;


        [VerticalGroup("Split/Properties")]
        public string MinionName;

        [VerticalGroup("Split/Properties")]
        public float Health;

        [VerticalGroup("Split/Properties")]
        public float Damage;
    }
}

