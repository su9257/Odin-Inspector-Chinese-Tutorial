using UnityEngine;

using Sirenix.OdinInspector;

namespace D_Game.Demo
{
    public class SimpleAttributeExamples0 : MonoBehaviour
    {
        /// <summary>
        /// 打开查看文件后缀为.unity的文件
        /// </summary>
        [FilePath(Extensions = ".unity")]
        public string ScenePath;
        /// <summary>
        /// 调用指定函数的返回值
        /// </summary>
        [FilePath(Extensions = "$ExtensionsList")]
        public string ObjectPath;

        [Button(ButtonSizes.Large)]
        public void SayHello()
        {
            Debug.Log("Hello button!");
        }

        public string ExtensionsList()
        {
            return ".cs,.unity,prefab";
        }
    }
}

