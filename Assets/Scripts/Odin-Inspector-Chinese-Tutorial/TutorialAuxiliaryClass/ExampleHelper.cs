using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ExampleHelper
{
    public static T GetScriptableObject<T>() where T : ScriptableObject
    {
        string suffix = "_ScriptableObject";
        string path = "Assets/TutorialAsset/ExampleScriptableObjects";

        string filter = typeof(T).ToString() + suffix;
        string[] array = AssetDatabase.FindAssets(filter, new[] { path });
        Debug.Log($"filter:{filter}-----path:{path}");

        T asset;
        if (array.Length > 0)
        {
            asset = AssetDatabase.LoadAssetAtPath<T>(path + "/" + typeof(T).ToString() + suffix + ".asset");
            Debug.Log($"加载文件：{asset}");
        }
        else
        {
            asset = ScriptableObject.CreateInstance<T>();
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(T).ToString() + suffix + ".asset");
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            Debug.Log($"创建并保存文件：{assetPathAndName}");
        }
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
        return asset;
    }

    public static string GetString()
    {
        return "菜鸟海澜";
    }

}
