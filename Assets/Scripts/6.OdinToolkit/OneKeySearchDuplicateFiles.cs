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
    [DictionaryDrawerSettings(KeyLabel = "MD5值", ValueLabel = "文件名称列表")]
    private Dictionary<string, List<string>> sameMD5Group = new Dictionary<string, List<string>>();

    [ShowInInspector]
    [DictionaryDrawerSettings(KeyLabel = "文件名称", ValueLabel = "绝对路径列表")]
    private Dictionary<string, List<string>> sameNameGroup = new Dictionary<string, List<string>>();

    [ShowInInspector]
    [TitleGroup("重复文件列表")]
    [HorizontalGroup("重复文件列表/重复文件")]
    [BoxGroup("重复文件列表/重复文件/MD5值相同", CenterLabel = true)]
    [PropertyOrder(1000)]
    [InfoBox("发现相同MD5值文件.", InfoMessageType.Error, "CheckSameMD5ResultGroup")]
    [ShowIf("$CheckSameMD5ResultGroup")]
    [DictionaryDrawerSettings(KeyLabel = "MD5值", ValueLabel = "相同MD5值文件名称")]
    private Dictionary<string, List<string>> sameMD5Result5Group = new Dictionary<string, List<string>>();


    [BoxGroup("重复文件列表/重复文件/名称值相同", CenterLabel = true)]
    [ShowInInspector]
    [PropertyOrder(1000)]
    [InfoBox("发现相同名称文件.", InfoMessageType.Error, "CheckSameNameResultGroup")]
    [ShowIf("$CheckSameNameResultGroup")]
    [DictionaryDrawerSettings(KeyLabel = "相同文件名称", ValueLabel = "对应绝对路径列表")]
    private Dictionary<string, List<string>> sameNameResultGroup = new Dictionary<string, List<string>>();

    public bool CheckSameMD5ResultGroup()
    {
        return sameMD5Result5Group.Count > 0;
    }

    private bool CheckSameNameResultGroup()
    {
        return sameNameResultGroup.Count > 0;
    }

    [PropertySpace(10,20)]
    [ShowIf("@ IsToggled== false")]
    [Button("开始搜索", ButtonSizes.Large)]
    public void StartSearch()
    {
        if (string.IsNullOrEmpty(targetSearchFolder))
        {
            targetSearchFolder = Application.dataPath;
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
        sameMD5Group.Clear();
        sameNameGroup.Clear();
        sameMD5Result5Group.Clear();
        sameNameResultGroup.Clear();
        fileInfoIEnumerator = null;
    }
    /// <summary>
    /// 过滤掉没有重复文件的数据
    /// </summary>
    private void FilterDictionary()
    {
        sameMD5Result5Group = sameMD5Group.Where(x => x.Value.Count > 1).ToDictionary(p=>p.Key, p => p.Value);
        sameNameResultGroup = sameNameGroup.Where(x => x.Value.Count > 1).ToDictionary(p => p.Key, p => p.Value);
    }

    [ReadOnly]
    [ProgressBar(0, "maxCount", DrawValueLabel = true, ValueLabelAlignment = TextAlignment.Left, ColorMember = "GetHealthBarColor", Height = 30)]
    [ShowInInspector]
    [HideLabel]
    [ShowIf("@ IsToggled== true")]
    public int MaxCount { get; set; }//绘制进度条

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
                //获取对应Hash值
                string hashValue = GetMD5HashFromFile(fileInfoIEnumerator.Current.FullName);
                if (!sameMD5Group.ContainsKey(hashValue))
                {
                    sameMD5Group[hashValue] = new List<string>();
                }
                sameMD5Group[hashValue].Add("名称为：" + fileInfoIEnumerator.Current.Name);

                //获取名称
                string fileName = fileInfoIEnumerator.Current.Name;

                if (!sameNameGroup.ContainsKey(fileName))
                {
                    sameNameGroup[fileName] = new List<string>();
                }
                sameNameGroup[fileName].Add("路径为：" + fileInfoIEnumerator.Current.FullName);

                ++MaxCount;
            }
            else
            {
                EditorApplication.update -= Updte;
                IsToggled = false;
                FilterDictionary();
                Debug.Log("<color=green>注销</color>");
            }
        }
    }

    /// <summary>
    /// 计算文件MD5值
    /// </summary>
    /// <param name="fileFullName"></param>
    /// <returns></returns>
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
}
