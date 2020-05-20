using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UINodeCollection : MonoBehaviour
{
    [SerializeField]
    [ListDrawerSettings(DraggableItems = false, Expanded = false)]
    private List<UINodeGroup> uINodes = new List<UINodeGroup>();


    #region 编辑器

#if UNITY_EDITOR
    const string k_Tab = "    ";
    public string className;

#pragma warning disable CS0649
    [ShowInInspector]
    [LabelText("选择需要生成的分部类")]
    [FilePath(Extensions = "cs, lua", AbsolutePath = true)]
    private string filePath;
#pragma warning restore CS0649

    [Button("导出对应的分部类", ButtonSizes.Large)]
    private void ExportPartialScript()
    {
        if (string.IsNullOrEmpty(filePath))
        {
            UnityEditor.EditorUtility.DisplayDialog("警告", "没有选择需要生成的分部类", "确定");
            return;
        }
        if (IsHaveRepetitiveName()) return;

        //获取对应的类名称
        var layerArray = filePath.Split(Path.AltDirectorySeparatorChar);
        className = layerArray[layerArray.Length - 1].Split('.')[0];
        //生成绝对路径
        string path = filePath.Replace(className, className + "Extention");

        StringBuilder content = new StringBuilder();
        //添加对应的注释
        content.AppendLine(CreateAnnotation().ToString());
        //添加命名空间
        content.Append(AdditionalNamespacesToString());
        //添加内容
        content.AppendLine("public partial class " + className + "\r\n" + "{\r\n");
        for (int i = 0; i < uINodes.Count; i++)
        {
            content.AppendLine(CreateOneGroup(uINodes[i]));
        }
        content.AppendLine("}\r\n");

        CreateScript(path, content);
        UnityEditor.AssetDatabase.Refresh();
        Debug.Log("生成代码完毕");
    }

    [Button("为组件进行赋值", ButtonSizes.Large)]
    private void SetComponentValue()
    {
        string nameSpace = "Assembly-CSharp";
        var assembly = Assembly.Load(nameSpace);
        var tempType = assembly.GetType(className);
        var type = transform.GetComponent(tempType);
        var fieldInfos = type.GetType().GetFields();

        for (int i = 0; i < fieldInfos.Length; i++)
        {
            var item = fieldInfos[i];
            var targetType = item.FieldType;

            var temp = uINodes.Where(a => a.typeName == targetType.Name)//筛选类型
                .SelectMany(a => a.nodes)
                .Where(t => t.name.Replace(" ", "") == item.Name)
                .FirstOrDefault();
            var targetValue = temp.gameObject.GetComponent(targetType);
            item.SetValue(type, targetValue);
        }
    }

    private StringBuilder CreateAnnotation()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("//开发者：海澜");
        stringBuilder.AppendLine("//描述：快速查找对应UI组件节点及代码绑定");
        stringBuilder.AppendLine("//脚本创建时间：" + DateTime.Now);
        stringBuilder.AppendLine(
@"//********************************
//本脚本为自动创建【切勿更改】
//********************************");
        return stringBuilder;
    }
    private string AdditionalNamespacesToString()
    {
        return
            "using System;\r\n" +
            "using System.Collections;\r\n" +
            "using System.Collections.Generic;\r\n" +
            "using System.IO;\r\n" +
            "using System.Linq;\r\n" +
            "using UnityEngine;\r\n" +
            "using UnityEngine.UI;\r\n" +
            "using Sirenix.OdinInspector; \r\n" +
            "using TMPro; \r\n" +
            "\r\n";
    }
    private string CreateOneGroup(UINodeGroup uINodeGroup)
    {
        string temp = "";
        var nodes = uINodeGroup.nodes;
        string typeName = uINodeGroup.typeName;
        for (int i = 0; i < nodes.Count; i++)
        {
            temp += k_Tab + $"public {typeName} {nodes[i].name.Replace(" ", "")};\r\n";
        }
        return temp;
    }
    private void CreateScript(string fileName, StringBuilder content)
    {
        string path = fileName;

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8))
            {
                writer.Write(content.ToString());
            }
        }
    }

    private bool IsHaveRepetitiveName()
    {
        string content = "";
        for (int i = 0; i < uINodes.Count; i++)
        {
            content += GetRepetitiveName(uINodes[i]);
        }
        if (!string.IsNullOrEmpty(content))
        {
            UnityEditor.EditorUtility.DisplayDialog("发现重复元素", content, "确定");
            return true;
        }
        return false;
    }

    private string GetRepetitiveName(UINodeGroup uINodeGroup)
    {
        var nodes = uINodeGroup.nodes;
        //先去重复
        //然后查找赌赢Key的个数 ，大于1就是重复
        List<string> strList = new List<string>();
        for (int i = 0; i < nodes.Count; i++)
        {
            strList.Add(nodes[i].name);
        }

        var group = strList.GroupBy(str => str).Where(g => g.Count() > 1).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
        string content = "";
        for (int i = 0; i < group.Count; i++)
        {
            content += $"重复元素：{group[i].Element} 重复的个数为：{group[i].Counter}";
        }
        return content;
    }


#endif

    #endregion

    [Serializable]
    private class UINodeGroup
    {
#pragma warning disable CS0649
        [LabelText("节点类型")]
        [ValueDropdown("GetFilteredTypeList")]
        public string typeName;
#pragma warning restore CS0649

        [ChildGameObjectsOnly]
        [ValidateInput("ValidateComponent", "填对对应的组件非指定类型", InfoMessageType.Error)]
        public List<UnityEngine.Component> nodes = new List<UnityEngine.Component>();

        #region 编辑器

#if UNITY_EDITOR
        /// <summary>
        /// typeName类型过滤
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetFilteredTypeList()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                .Where(t => !t.IsAbstract)
                .Where(t => !t.IsGenericTypeDefinition)
                .Where(t => typeof(Component).IsAssignableFrom(t))
                .Where(t => t.Namespace == "UnityEngine.UI")
                .Where(t => t.IsPublic);

            types = types.AppendWith(typeof(Transform));

            var typeNames = types.Select(t => t.Name);
            return typeNames;
        }

        /// <summary>
        /// 对添加节点类型的验证
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private bool ValidateComponent(List<UnityEngine.Component> nodes)
        {
            if (nodes.Count <= 0 || typeName == "Transform") return true;

            string nameSpace = "UnityEngine.UI";
            var node = nodes[nodes.Count - 1];

            var assembly = Assembly.Load(nameSpace);
            var tempType = assembly.GetType(nameSpace + "." + typeName);
            var tempComponent = node.GetComponent(tempType);

            return tempComponent != null;
        }
#endif

        #endregion
    }

}
