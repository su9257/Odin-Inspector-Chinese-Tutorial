using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Searchable]
public class SearchableExample_1 : MonoBehaviour
{
    public List<string> strings = new List<string>(Enumerable.Range(1, 10).Select(i => "Str Element " + i));

    public List<ExampleStruct> searchableList = new List<ExampleStruct>(Enumerable.Range(1, 10).Select(i => new ExampleStruct(i)));

    [Serializable]
    public struct ExampleStruct
    {
        public string Name;
        public int Number;
        public ExampleEnum Enum;

        public ExampleStruct(int nr) : this()
        {
            this.Name = "Element " + nr;
            this.Number = nr;
            this.Enum = (ExampleEnum)ExampleHelper.RandomInt(0, 5);
        }
    }

    public enum ExampleEnum
    {
        One, Two, Three, Four, Five
    }
}
