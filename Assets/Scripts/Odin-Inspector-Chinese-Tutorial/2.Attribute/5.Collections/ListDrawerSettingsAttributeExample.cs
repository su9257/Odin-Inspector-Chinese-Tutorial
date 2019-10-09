using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDrawerSettingsAttributeExample : MonoBehaviour
{
    [PropertyOrder(int.MinValue), OnInspectorGUI]
    private void DrawIntroInfoBox()
    {
        SirenixEditorGUI.InfoMessageBox("Odin开箱即用，无需检查，即可全面升级检查器中列表和数组的图形.");
    }

    [Title("List Basics")]
    [InfoBox("现在可以拖动列表元素来重新排序并逐个删除它们，并且列表具有分页功能(尝试添加大量元素!)您仍然可以从项目视图一次将许多资产拖到列表中—只需将它们拖到列表本身，并将它们插入到您想要添加它们的地方.")]
    public List<float> FloatList;

    [InfoBox("将[Range]属性应用于此列表，代替传统的float形式")]
    [Range(0, 1)]
    public float[] FloatRangeArray;

    [ListDrawerSettings(IsReadOnly = true)]
    public int[] ReadOnlyArray1 = new int[] { 1, 2, 3 };

    [ReadOnly]
    public int[] ReadOnlyArray2 = new int[] { 1, 2, 3 };

    public SomeOtherStruct[] SomeStructList;

    [Title("Advanced List Customization")]
    [InfoBox("Using [ListDrawerSettings], lists can be customized in a wide variety of ways.")]
    [ListDrawerSettings(NumberOfItemsPerPage = 5)]
    public int[] FiveItemsPerPage;

    [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "SomeString")]
    public SomeStruct[] IndexLabels;

    [ListDrawerSettings(DraggableItems = false, Expanded = false, ShowIndexLabels = true, ShowPaging = false, ShowItemCount = false, HideRemoveButton = true)]
    public int[] MoreListSettings = new int[] { 1, 2, 3 };

    [ListDrawerSettings(OnBeginListElementGUI = "BeginDrawListElement", OnEndListElementGUI = "EndDrawListElement")]
    public SomeStruct[] InjectListElementGUI;

    [ListDrawerSettings(OnTitleBarGUI = "DrawRefreshButton")]
    public List<int> CustomButtons;

    [ListDrawerSettings(CustomAddFunction = "CustomAddFunction")]
    public List<int> CustomAddBehaviour;

    private void BeginDrawListElement(int index)
    {
        SirenixEditorGUI.BeginBox(this.InjectListElementGUI[index].SomeString);
    }

    private void EndDrawListElement(int index)
    {
        SirenixEditorGUI.EndBox();
    }

    private void DrawRefreshButton()
    {
        if (SirenixEditorGUI.ToolbarButton(EditorIcons.Refresh))
        {
            Debug.Log(this.CustomButtons.Count.ToString());
        }
    }

    private int CustomAddFunction()
    {
        return this.CustomAddBehaviour.Count+100;
    }



    [Serializable]
    public struct SomeStruct
    {
        public string SomeString;
        public int One;
        public int Two;
        public int Three;
    }

    [Serializable]
    public struct SomeOtherStruct
    {
        [HorizontalGroup("Split", 55), PropertyOrder(-1)]
        [PreviewField(50, Sirenix.OdinInspector.ObjectFieldAlignment.Left), HideLabel]
        public UnityEngine.MonoBehaviour SomeObject;

        [FoldoutGroup("Split/$Name", false)]
        public int A, B, C;

        [FoldoutGroup("Split/$Name", false)]
        public int Two;

        [FoldoutGroup("Split/$Name", false)]
        public int Three;

        private string Name { get { return this.SomeObject ? this.SomeObject.name : "Null"; } }
    }
}
