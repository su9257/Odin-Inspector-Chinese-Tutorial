using UnityEngine;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace D_Game.Demo
{
    public class TestWindow : OdinEditorWindow
    {
        [MenuItem("My Game/TestWindow")]
        private static void OpenWindow()
        {
            GetWindow<TestWindow>().Show();
            GetWindow<SomeWindow>().Show();
            Debug.Log("打开TestWindow");
        }

        [PropertyOrder(-10)]
        [HorizontalGroup]
        [Button(ButtonSizes.Large)]
        public void SomeButton1() { }

        [HorizontalGroup]
        [Button(ButtonSizes.Large)]
        public void SomeButton2() { }

        [HorizontalGroup]
        [Button(ButtonSizes.Large)]
        public void SomeButton3() { }

        [HorizontalGroup]
        [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
        public void SomeButton4() { }

        [HorizontalGroup]
        [Button(ButtonSizes.Large), GUIColor(1, 0.5f, 0)]
        public void SomeButton5() { }

        [TableList]
        public List<SomeType> SomeTableData;
    }
}

