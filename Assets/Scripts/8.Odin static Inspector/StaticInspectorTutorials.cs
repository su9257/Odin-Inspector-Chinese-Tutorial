using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class StaticInspectorTutorials : MonoBehaviour
{
    public enum TempEnum
    {
        One,Two,Three
    }
    public static TempEnum tempEnum;
    public static string tempStr;
    public static int tempInt;
    public static List<StaticInspectorTutorials_One> staticInspectorTutorials_Ones = new List<StaticInspectorTutorials_One>();

    [Button(ButtonSizes.Large)]
    public static void TestStaticFunction()
    {
        Debug.Log("TestFunction");
    }
    [Button(ButtonSizes.Large, ButtonStyle.FoldoutButton)]
    public static void TestStaticFunction(string str)
    {
        Debug.Log($"TestFunction:{str}");
    }

    [Button(ButtonSizes.Large, ButtonStyle.FoldoutButton)]
    public static void TestStaticFunction(List<string> tempList)
    {
        for (int i = 0; i < tempList.Count; i++)
        {
            Debug.Log($"List Index :{i}---value:{tempList[i]}");
        }
    }

    public void NoStaticFunction()
    {
        Debug.Log("NoStaticFunction");
    }
}

public  class StaticInspectorTutorials_One
{
    public static string tempStr;
}
