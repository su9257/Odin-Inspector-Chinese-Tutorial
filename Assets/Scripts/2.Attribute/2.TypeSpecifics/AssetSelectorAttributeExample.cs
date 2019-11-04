using UnityEngine;

using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
public class AssetSelectorAttributeExample : MonoBehaviour
{
    [AssetSelector]
    public Material AnyAllMaterials;
    [AssetSelector]
    public Material[] ListOfAllMaterials;

    [PropertySpace(40)]
    [AssetSelector(FlattenTreeView = false)]//默认树状显示
    public PhysicMaterial TreeView;
    [AssetSelector(FlattenTreeView = true)]//非默认树状显示
    public PhysicMaterial NoTreeView;


    [PropertySpace(40)]
    [AssetSelector(Paths = "Assets/TutorialAsset/ExampleScriptableObjects")]
    public ScriptableObject ScriptableObjectsFromFolder;
    [AssetSelector(Paths = "Assets/TutorialAsset/ExampleScriptableObjects|Assets/Plugins/Sirenix/Odin Inspector")]
    public ScriptableObject ScriptableObjectsFromMultipleFolders;

    [PropertySpace(40)]
    [AssetSelector(Filter = "New Animation t:AnimationClip l:自定义标签")]
    public UnityEngine.Object AssetDatabaseSearchFilters;

    [Title("辅助性功能")]
    [AssetSelector(DisableListAddButtonBehaviour = true)] //开启后加号不会出现树形下拉条以弹窗形式出现
    public List<GameObject> DisableListAddButtonBehaviour;

    [PropertySpace(40)]
    [AssetSelector(DrawDropdownForListElements = false)]
    public List<GameObject> DisableListElementBehaviour_False;
    [AssetSelector(DrawDropdownForListElements = true)]
    public List<GameObject> DisableListElementBehaviour_True;

    [PropertySpace(40)]
    [AssetSelector(ExcludeExistingValuesInList = true)]
    public List<GameObject> ExcludeExistingValuesInList_True;
    [AssetSelector(ExcludeExistingValuesInList = false)]
    public List<GameObject> ExcludeExistingValuesInList_False;

    [PropertySpace(40)]
    [AssetSelector(IsUniqueList = true)]
    public List<GameObject> DisableUniqueListBehaviour_True;
    [AssetSelector(IsUniqueList = false)]
    public List<GameObject> DisableUniqueListBehaviour_False;

    [PropertySpace(40)]
    [AssetSelector(ExpandAllMenuItems = true)]//下拉条是否展开
    public List<GameObject> ExpandAllMenuItems_True;
    [AssetSelector(ExpandAllMenuItems = false)]
    public List<GameObject> ExpandAllMenuItems_False;

    [PropertySpace(40)]
    [AssetSelector(DropdownTitle = "最定义下拉列表标题")]
    public List<GameObject> CustomDropdownTitle;
}