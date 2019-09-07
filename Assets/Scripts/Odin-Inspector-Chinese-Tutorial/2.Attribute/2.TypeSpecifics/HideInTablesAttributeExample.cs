using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;



public class HideInTablesAttributeExample : MonoBehaviour
{
    public MyItem Item = new MyItem();

    [TableList]//以表格形式展示List中的成员
    public List<MyItem> Table = new List<MyItem>()
     {
    new MyItem(),
    new MyItem(),
    new MyItem(),
     };

    [Serializable]
    public class MyItem
    {
        public string A;

        public int B;

        [HideInTables]//此字段在表格中不显示
        public int Hidden;
    }
}


