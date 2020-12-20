using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchableExample_2 : MonoBehaviour
{
    [Searchable]
    public ExampleClass searchableClass = new ExampleClass();

    [Searchable]
    public List<ExampleStruct> searchableList = new List<ExampleStruct>(Enumerable.Range(1, 10).Select(i => new ExampleStruct(i)));

    [Searchable(FilterOptions = SearchFilterOptions.ISearchFilterableInterface)]
    public List<FilterableBySquareStruct> customFiltering = new List<FilterableBySquareStruct>(Enumerable.Range(1, 10).Select(i => new FilterableBySquareStruct(i)));

    [Serializable]
    public class ExampleClass
    {
        public string SomeString = "Saehrimnir is a tasty delicacy";
        public int SomeInt = 13579;

        public DataContainer DataContainerOne = new DataContainer() { Name = "Example Data Set One" };
        public DataContainer DataContainerTwo = new DataContainer() { Name = "Example Data Set Two" };
    }

    [Serializable, Searchable] // You can also apply it on a type like this, and it will become searchable wherever it appears
    public class DataContainer
    {
        public string Name;
        public List<ExampleStruct> Data = new List<ExampleStruct>(Enumerable.Range(1, 10).Select(i => new ExampleStruct(i)));
    }

    [Serializable]
    public struct FilterableBySquareStruct : ISearchFilterable
    {
        public int Number;

        [ShowInInspector, DisplayAsString, EnableGUI]
        public int Square { get { return this.Number * this.Number; } }

        public FilterableBySquareStruct(int nr)
        {
            this.Number = nr;
        }

        public bool IsMatch(string searchString)
        {
            return searchString.Contains(Square.ToString());
        }
    }

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
