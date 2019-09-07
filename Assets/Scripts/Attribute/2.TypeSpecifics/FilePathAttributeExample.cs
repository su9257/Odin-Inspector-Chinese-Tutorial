using Sirenix.OdinInspector;
using UnityEngine;


public class FilePathAttributeExample : MonoBehaviour
{
    // 默认情况下，FolderPath提供了一个相对于Unity项目的路径。
    [FilePath]
    public string UnityProjectPath;

    // 可以提供自定义父路径。父路径可以是相对于Unity项目的，也可以是绝对的。
    [FilePath(ParentFolder = "Assets/Plugins/Sirenix")]
    public string RelativeToParentPath;

    // 使用父路径，FilePath还可以提供相对于resources文件夹的路径。
    [FilePath(ParentFolder = "Assets/Resources")]
    public string ResourcePath;

    // 提供一个逗号分隔的允许扩展列表。点（.）是可选的。
    [FilePath(Extensions = "cs")]
    [BoxGroup("Conditions")]
    public string ScriptFiles;

    // By setting AbsolutePath to true, the FilePath will provide an absolute path instead.
    [FilePath(AbsolutePath = true)]
    public string AbsolutePath;

    // FilePath can also be configured to show an error, if the provided path is invalid.
    [FilePath(RequireExistingPath = true)]
    public string ExistingPath;

    // By default, FilePath will enforce the use of forward slashes. It can also be configured to use backslashes instead.
    [FilePath(UseBackslashes = true)]
    public string Backslashes;

    // FilePath also supports member references with the $ symbol.
    [FilePath(ParentFolder = "$DynamicParent", Extensions = "$DynamicExtensions")]
    [BoxGroup("Member referencing")]
    public string DynamicFilePath;

    [BoxGroup("Member referencing")]
    public string DynamicParent = "Assets/Plugin/Sirenix";

    [BoxGroup("Member referencing")]
    public string DynamicExtensions = "cs, unity, jpg";

    // FilePath also supports lists and arrays.
    [FilePath(ParentFolder = "Assets/Plugins/Sirenix/Demos/Odin Inspector")]
    [BoxGroup("Lists")]
    public string[] ListOfFiles;
}


