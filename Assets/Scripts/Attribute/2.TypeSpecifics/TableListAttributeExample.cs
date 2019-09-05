using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TableListAttributeExample : MonoBehaviour
{
    [TableList(ShowIndexLabels = true)]
    public List<SomeCustomClass> TableListWithIndexLabels = new List<SomeCustomClass>()
{
    new SomeCustomClass(),
    new SomeCustomClass(),
};

    [TableList(DrawScrollView = true, MaxScrollViewHeight = 200, MinScrollViewHeight = 100)]
    public List<SomeCustomClass> MinMaxScrollViewTable = new List<SomeCustomClass>()
{
    new SomeCustomClass(),
    new SomeCustomClass(),
};

    [TableList(DrawScrollView = false)]
    public List<SomeCustomClass> AlwaysExpandedTable = new List<SomeCustomClass>()
{
    new SomeCustomClass(),
    new SomeCustomClass(),
};

    [TableList(ShowPaging = true, DrawScrollView = false)]
    public List<SomeCustomClass> TableWithPaging = new List<SomeCustomClass>()
{
    new SomeCustomClass(),
    new SomeCustomClass(),
    new SomeCustomClass(),
    new SomeCustomClass(),
    new SomeCustomClass(),
    new SomeCustomClass(),
    new SomeCustomClass(),
};

    [Serializable]
    public class SomeCustomClass
    {
        [TableColumnWidth(57, Resizable = false)]
        [PreviewField(Alignment = ObjectFieldAlignment.Center)]
        public Texture Icon;

        [TextArea]
        public string Description = ExampleHelper.GetString();

        [VerticalGroup("Combined Column"), LabelWidth(22)]
        public string A, B, C;

        [TableColumnWidth(60)]
        [Button, VerticalGroup("Actions")]
        public void Test1() { }

        [TableColumnWidth(60)]
        [Button, VerticalGroup("Actions")]
        public void Test2() { }
    }
}


