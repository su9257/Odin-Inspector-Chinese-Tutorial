using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class ValueDropdownAttributeExample : MonoBehaviour
{

    /*【MemberName】*/
    [PropertySpace(40, 0)]
    [ValueDropdown("TextureSizes")]
    public int SomeSize1;
    private static int[] TextureSizes = new int[] { 32, 64, 128, 256, 512, 1024, 2048, 4096 };

    [ValueDropdown("FriendlyTextureSizes")]
    public int SomeSize2;
    private static IEnumerable FriendlyTextureSizes = new ValueDropdownList<int>()
    {
      { "Small", 256 },
      { "Medium", 512 },
      { "Large", 1024 },
    };

    /*【SortDropdownItems】默认为false 开启后为下拉列表为根据Key升序排序*/
    [PropertySpace(40, 0)]
    [ValueDropdown("SortList1")]
    public int SomeSize3;
    private IEnumerable SortList1 = new ValueDropdownList<int>()
    {
      { "Small", 256 },
      { "Medium", 512 },
      { "Large", 1024 },
       { "A", 128 },
    };
    [PropertySpace(0, 40)]
    [ValueDropdown("SortList2", SortDropdownItems = true)]
    public int SomeSize4;
    private List<ValueDropdownItem<int>> SortList2 = new ValueDropdownList<int>()
    {
      { "Small", 256 },
      { "Medium", 512 },
      { "Large", 1024 },
      { "A", 128 },
    };
    [PropertySpace(0, 40)]
    [ValueDropdown("TextureSizes", DropdownTitle = "下拉条标题")]
    public int SomeSize5;

    [PropertySpace(0, 40)]
    [ValueDropdown("TextureSizes", DropdownHeight = 80)]
    public int SomeSize6;

    [PropertySpace(0, 40)]
    [ValueDropdown("TextureSizes", DropdownWidth = 100)]
    public int SomeSize7;

    [PropertySpace(0, 40)]
    [ValueDropdown("TreeViewOfInts", FlattenTreeView = true)]//默认为false，如果设置为true则禁用树形结构使用平铺模式
    public int SomeSize8;


    [PropertySpace(0, 40)]
    [ValueDropdown("TreeViewOfInts", DoubleClickToConfirm = true)]//需要双击才能选中
    public int SomeSize9;

    [PropertySpace(0, 40)]
    [ValueDropdown("TreeViewOfInts", HideChildProperties = true, DisableGUIInAppendedDrawer = true)]//
    public int SomeSize10;


    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/
    /*【MemberName】*/

    /// <summary>
    /// AppendNextDrawer 为 true 会绘制一个下拉的按钮，非传统的宽度下拉条
    /// </summary>
    [ValueDropdown("FriendlyTextureSizes", AppendNextDrawer = true)]
    public static int SomeSize30;
    [ValueDropdown("FriendlyTextureSizes", AppendNextDrawer = true, HideChildProperties = true)]
    public List<int> array = new List<int>()
    {
        SomeSize30,SomeSize40
    };

    /// <summary>
    /// DisableGUIInAppendedDrawer是否可以更改对应栏目的数值
    /// </summary>
    [ValueDropdown("FriendlyTextureSizes", AppendNextDrawer = true, DisableGUIInAppendedDrawer = true)]
    public static int SomeSize40;

    [ValueDropdown("GetListOfMonoBehaviours", AppendNextDrawer = true, HideChildProperties = true)]
    public MonoBehaviour SomeMonoBehaviour;
    private IEnumerable<MonoBehaviour> GetListOfMonoBehaviours()
    {
        return GameObject.FindObjectsOfType<MonoBehaviour>();
    }

    [ValueDropdown("KeyCodes")]
    public KeyCode FilteredEnum;
    private static IEnumerable<KeyCode> KeyCodes = Enumerable.Range((int)KeyCode.Alpha0, 10).Cast<KeyCode>();


    [ValueDropdown("TreeViewOfInts", ExpandAllMenuItems = true)]
    public List<int> IntTreeview = new List<int>() { 1, 2, 7 };
    /// <summary>
    /// 以“/”符号作为类别分隔符
    /// </summary>
    private IEnumerable TreeViewOfInts = new ValueDropdownList<int>()
{
    { "Node 1/Node 1.1", 1 },
    { "Node 1/Node 1.2", 2 },
    { "Node 2/Node 2.1", 3 },
    { "Node 3/Node 3.1", 4 },
    { "Node 3/Node 3.2", 5 },
    { "Node 1/Node 3.1/Node 3.1.1", 6 },
    { "Node 1/Node 3.1/Node 3.1.2", 7 },
    { "Node 1", -1 },
    { "Node 2", -2 },
    { "Node 3", -3 },
        { "Node 4", -1 },
    { "Node 5", -2 },
    { "Node 6", -3 },
        { "Node 7", -1 },
    { "Node 8", -2 },
    { "Node 9", -3 },
        { "Node 10", -1 },
    { "Node 11", -2 },
        { "Node 12", -1 },
    { "Node 13", -2 },
    { "Node 14", -3 },
        { "Node 15", -1 },
    { "Node 16", -2 },
        { "Node 17", -1 },
    { "Node 18", -2 },
    { "Node 19", -3 },
        { "Node 20", -1 },
    { "Node 21", -2 },
    { "Node 22", -3 },
        { "Node 23", -1 },
    { "Node 24", -2 },
    { "Node 25", -3 },
    { "Node 26", -3 },
    { "Node 27", -3 },
};

    /// <summary>
    /// IsUniqueList为true 每个Item上面有一个勾选框
    /// </summary>
    [ValueDropdown("GetAllSceneObjects", IsUniqueList = false, HideChildProperties = false)]
    public List<GameObject> UniqueGameobjectList;
    private static IEnumerable GetAllSceneObjects()
    {
        Func<Transform, string> getPath = null;
        getPath = x => (x ? getPath(x.parent) + "/" + x.gameObject.name : "");//三元运算符 其中X为Transform
        return GameObject.FindObjectsOfType<GameObject>().Select(x => new ValueDropdownItem(getPath(x.transform), x));
    }

    /// <summary>
    /// ExcludeExistingValuesInList 为 ture则选中的item不在出现在等待选择的列下拉表中
    /// DrawDropdownForListElements 为 true  每个item都有一个下拉列表
    /// </summary>
    [ValueDropdown("GetAllSceneObjects", IsUniqueList = false, DropdownTitle = "Select Scene Object", DrawDropdownForListElements = false, ExcludeExistingValuesInList = true)]
    public List<GameObject> UniqueGameobjectListMode2;


    private static IEnumerable GetAllScriptableObjects()
    {
        return UnityEditor.AssetDatabase.FindAssets("t:ScriptableObject")
            .Select(x => UnityEditor.AssetDatabase.GUIDToAssetPath(x))
            .Select(x => new ValueDropdownItem(x, UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(x)));
    }

    private static IEnumerable GetAllSirenixAssets()
    {
        var root = "Assets/Plugins/Sirenix/";

        return UnityEditor.AssetDatabase.GetAllAssetPaths()
            .Where(x => x.StartsWith(root))
            .Select(x => x.Substring(root.Length))
            .Select(x => new ValueDropdownItem(x, UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(root + x)));
    }
}
