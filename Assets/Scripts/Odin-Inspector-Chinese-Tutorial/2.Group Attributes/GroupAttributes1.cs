using UnityEngine;
using Sirenix.OdinInspector;


namespace D_Game.Demo
{
    public class GroupAttributes1 : MonoBehaviour
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Buttons in Boxes")]
        [HorizontalGroup("Buttons in Boxes/Horizontal",100)]

        [BoxGroup("Buttons in Boxes/Horizontal/One")]
        public void Button1() { }

        [Button(ButtonSizes.Large)]
        [BoxGroup("Buttons in Boxes/Horizontal/Two")]
        public void Button2() { }

        [Button]
        [BoxGroup("Buttons in Boxes/Horizontal/Double")]
        public void Accept() { }

        [Button]
        [BoxGroup("Buttons in Boxes/Horizontal/Double")]
        public void Cancel() { }
    }
}

