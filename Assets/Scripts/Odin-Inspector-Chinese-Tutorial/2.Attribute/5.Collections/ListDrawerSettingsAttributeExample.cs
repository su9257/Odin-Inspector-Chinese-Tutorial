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
        SirenixEditorGUI.InfoMessageBox("Out of the box, Odin significantly upgrades the drawing of lists and arrays in the inspector - across the board, without you ever lifting a finger.");
    }

    [Title("List Basics")]
    [InfoBox("List elements can now be dragged around to reorder them and deleted individually, and lists have paging (try adding a lot of elements!). You can still drag many assets at once into lists from the project view - just drag them into the list itself and insert them where you want to add them.")]
    public List<float> FloatList;

    [InfoBox("Applying a [Range] attribute to this list instead applies it to all of its float entries.")]
    [Range(0, 1)]
    public float[] FloatRangeArray;

    [InfoBox("Lists can be made read-only in different ways.")]
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
        return this.CustomAddBehaviour.Count;
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
