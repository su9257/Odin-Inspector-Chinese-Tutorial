using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using System.Threading;

public class OneKeySearchDuplicateFiles : SerializedScriptableObject
{
    private bool IsToggled;
    private int maxCount;
    private IEnumerator<FileInfo> fileInfoIEnumerator;

    [PropertySpace(10)]
    [Title("需要搜索的文件夹", "默认为Asset全目录", titleAlignment: TitleAlignments.Split)]
    [FolderPath(ParentFolder = "Assets", RequireExistingPath = true, AbsolutePath = true)]
    [LabelText("选择你要搜索的文件夹")]
    public string targetSearchFolder;

    [ShowInInspector]
    private Dictionary<string, List<string>> objectGroup = new Dictionary<string, List<string>>();

    [ShowIf("@ IsToggled== false")]
    [Button("开始搜索", ButtonSizes.Large)]
    public void StartSearch()
    {
        if (string.IsNullOrEmpty(targetSearchFolder))
        {
            targetSearchFolder = Application.dataPath;
            Debug.Log(targetSearchFolder);
        }
        ResetData();
        DirectoryInfo directoryInfo = new DirectoryInfo(targetSearchFolder);
        var filesGroup = directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Where(x => x.Extension != ".meta");

        maxCount = filesGroup.Count();
        fileInfoIEnumerator = filesGroup.GetEnumerator();
        IsToggled = true;
        EditorApplication.update += Updte;
    }
    private void ResetData()
    {
        maxCount = 0;
        MaxCount = 0;
        fileInfoIEnumerator = null;
    }

    private void FilterDictionary()
    {
        objectGroup = objectGroup.Where(x => x.Value.Count > 1).ToDictionary(p=>p.Key, p => p.Value);
    }

    [ReadOnly]
    [ProgressBar(0, "maxCount", DrawValueLabel = true, ValueLabelAlignment = TextAlignment.Left, ColorMember = "GetHealthBarColor", Height = 30)]
    [ShowInInspector]
    [HideLabel]
    [ShowIf("@ IsToggled== true")]
    public int MaxCount { get; set; }

    private Color GetHealthBarColor(int value)
    {
        maxCount = maxCount == 0 ? 1 : maxCount;
        return Color.Lerp(Color.red, Color.green, Mathf.Pow((float)value / maxCount, 2));
    }
    public void Updte()
    {
        if (IsToggled)
        {
            if (fileInfoIEnumerator.MoveNext())
            {
                string hashValue = GetMD5HashFromFile(fileInfoIEnumerator.Current.FullName);
                if (!objectGroup.ContainsKey(hashValue))
                {
                    objectGroup[hashValue] = new List<string>();
                }
                objectGroup[hashValue].Add("名称为：" + fileInfoIEnumerator.Current.Name);
                Debug.Log(hashValue);
                ++MaxCount;
            }
            else
            {
                EditorApplication.update -= Updte;
                IsToggled = false;
                FilterDictionary();
                Debug.Log("注销");
            }
        }
    }

    //[PropertyOrder(10000)]
    //[TextArea(10, 30)]
    //[LabelText("打印内容")]
    //public string LogContent;

    public string GetMD5HashFromFile(string fileFullName)
    {
        try
        {
            FileStream file = new FileStream(fileFullName, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();
            return BitConverter.ToString(retVal).ToLower().Replace("-", "");
        }
        catch
        {
            throw;
        }

    }

    public void TestGetFilePaths(string absolutePath)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(absolutePath);
        //遍历文件夹
        foreach (DirectoryInfo tempDirectoryInfo in directoryInfo.GetDirectories())
        {
            TestGetFilePaths(tempDirectoryInfo.FullName);
        }
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            Debug.Log(fileInfo.FullName);
        }
    }

    //GetFilePaths(before + "/UI", dic, ".png");
    private static void GetFilePaths(string absolutePath, Dictionary<string, string> _dic, string extension)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(absolutePath);
        //遍历文件夹
        foreach (DirectoryInfo tempDirectoryInfo in directoryInfo.GetDirectories())
        {
            GetFilePaths(tempDirectoryInfo.FullName, _dic, extension);
        }

        //遍历文件
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            if (fileInfo.Extension.ToLower().Equals(extension.ToLower()))
            {
                try
                {
                    string tempStr = fileInfo.FullName.Substring(fileInfo.FullName.LastIndexOf("\\Resources\\") + 11);
                    string value = tempStr.Substring(0, tempStr.Length - extension.Length);
                    _dic.Add(fileInfo.Name, value);
                }
                catch
                {
                    Debug.Log("<color=#FF4040>发现同名资源: </color>" + fileInfo.Name + " " + fileInfo.FullName.Substring(Application.dataPath.Length - "Asset".Length - 1));
                    Debug.Log("<color=#FF4040>已存在同名资源: </color>" + fileInfo.Name + " " + _dic[fileInfo.Name] + extension);
                }
            }
        }
    }
}
