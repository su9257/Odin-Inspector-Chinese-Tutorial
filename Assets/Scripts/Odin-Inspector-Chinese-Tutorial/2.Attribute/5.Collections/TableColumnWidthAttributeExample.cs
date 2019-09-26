using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableColumnWidthAttributeExample : MonoBehaviour
{
    [TableList]
    public List<MyItem> List = new List<MyItem>()
{
    new MyItem(),
    new MyItem(),
    new MyItem(),
};

    [Serializable]
    public class MyItem
    {
        [PreviewField(Height = 20)]
        [TableColumnWidth(30, Resizable = false)]
        public Texture2D Icon;

        [TableColumnWidth(60)]
        public int ID;

        public string Name;
    }
}
