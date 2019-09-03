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

    [AssetSelector(FlattenTreeView = true)]//非默认树状显示
    public PhysicMaterial NoTreeView;

    [AssetSelector(Paths = "Assets/MyScriptableObjects")]
    public ScriptableObject ScriptableObjectsFromFolder;

    [AssetSelector(Paths = "Assets/MyScriptableObjects|Assets/Other/MyScriptableObjects")]
    public Material ScriptableObjectsFromMultipleFolders;

    [AssetSelector(Filter = "New Animation t:AnimationClip l:自定义标签")]
    public UnityEngine.Object AssetDatabaseSearchFilters;

    [Title("Other Minor Features")]

    [AssetSelector(DisableListAddButtonBehaviour = true)] //开启后不会出现树形下拉条
    public List<GameObject> DisableListAddButtonBehaviour;

    [AssetSelector(DrawDropdownForListElements = false)]
    public List<GameObject> DisableListElementBehaviour;

    [AssetSelector(ExcludeExistingValuesInList = false)]
    public List<GameObject> ExcludeExistingValuesInList;

    [AssetSelector(IsUniqueList = false)]
    public List<GameObject> DisableUniqueListBehaviour;

    [AssetSelector(ExpandAllMenuItems = true)]
    public List<GameObject> ExpandAllMenuItems;

    [AssetSelector(DropdownTitle = "Custom Dropdown Title")]
    public List<GameObject> CustomDropdownTitle;

}

