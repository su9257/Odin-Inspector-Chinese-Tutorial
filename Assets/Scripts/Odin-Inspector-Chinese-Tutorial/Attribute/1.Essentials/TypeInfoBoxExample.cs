using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TypeInfoBoxExample : MonoBehaviour
{
    public MyType MyObject = new MyType();

    [ShowInInspector]
    [InfoBox("双击可以打开一个新的 Scripty object 面板.")]
    [InlineEditor]
    public MyScripty Scripty = null;



    public void Start()
    {
        Scripty = ExampleHelper.GetScriptableObject<MyScripty>();
    }


    [Serializable]
    [TypeInfoBox("TypeInfoBox属性可以放在类型定义上，并将导致在属性的上方绘制一个InfoBox。.")]
    public class MyType
    {
        public int Value;
    }

    [TypeInfoBox("TypeInfoBox特性还可以用于在对应实例化 Type顶部显示文本，例如MonoBehaviours or ScriptableObjects.")]
    public class MyScripty : ScriptableObject
    {
        public string MyText = ExampleHelper.GetString();
        [TextArea(5, 10)]
        public string Box;
    }

}


public static class ExampleHelper
{
    public static T GetScriptableObject<T>() where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");
        Debug.Log($"assetPathAndName：{assetPathAndName}");
        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        //Selection.activeObject = asset;
        return asset;
    }

    public static string GetString()
    {
        return "菜鸟海澜";
    }
}
