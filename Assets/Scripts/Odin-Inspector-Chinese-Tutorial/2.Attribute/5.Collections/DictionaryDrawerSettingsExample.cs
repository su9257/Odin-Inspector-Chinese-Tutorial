using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryDrawerSettingsExample : MonoBehaviour
{
    [ShowInInspector]
    [InfoBox("In order to serialize dictionaries, all we need to do is to inherit our class from SerializedMonoBehaviour.")]
    public Dictionary<int, Material> IntMaterialLookup = new Dictionary<int, Material>()
{

};
    [ShowInInspector]
    public Dictionary<string, string> StringStringDictionary = new Dictionary<string, string>()
{
    { "One", ExampleHelper.GetString() },
    { "Syv", ExampleHelper.GetString() },
};
    [ShowInInspector]
    [DictionaryDrawerSettings(KeyLabel = "自定义 Key 名称", ValueLabel = "自定义 Value 名称")]
    public Dictionary<SomeEnum, MyCustomType> CustomLabels = new Dictionary<SomeEnum, MyCustomType>()
{
    { SomeEnum.First, new MyCustomType() },
    { SomeEnum.Second, new MyCustomType() },
};
    [ShowInInspector]
    [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)]
    public Dictionary<string, List<int>> StringListDictionary = new Dictionary<string, List<int>>()
{
    { "Numbers", new List<int>(){ 1, 2, 3, 4, } },
};

    [ShowInInspector]
    [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.Foldout)]
    public Dictionary<SomeEnum, MyCustomType> EnumObjectLookup = new Dictionary<SomeEnum, MyCustomType>()
{
    { SomeEnum.Third, new MyCustomType() },
    { SomeEnum.Fourth, new MyCustomType() },
};

    [InlineProperty(LabelWidth = 90)]
    public struct MyCustomType
    {
        public int SomeMember;
        public GameObject SomePrefab;
    }

    public enum SomeEnum
    {
        First, Second, Third, Fourth, AndSoOn
    }
}
