
using System.Collections;

internal class EditorCoroutineFactory : ICoroutineFactory<EditorCoroutine>
{
    public EditorCoroutine Create(object owner, IEnumerator routine)
    {
        int ownerHash = GetOwnerHash(owner);
        string id = CreateId(ownerHash, routine);
        return new EditorCoroutine(ownerHash, routine, id);
    }

    public string CreateId(object owner, IEnumerator routine)
    {
        return CreateId(GetOwnerHash(owner), GetCoreMethodName(routine));
    }

    public string CreateId(object owner, string methodName)
    {
        return CreateId(GetOwnerHash(owner), methodName);
    }

    public string CreateId(int ownerHash, IEnumerator routine)
    {
        return CreateId(ownerHash, GetCoreMethodName(routine));
    }

    public string CreateId(int ownerHash, string methodName)
    {
        return ownerHash + "_" + methodName;
    }

    public int GetOwnerHash(object owner)
    {
        return owner?.GetHashCode() ?? -1;
    }

    public string GetCoreMethodName(IEnumerator routine)
    {
        string methodName = routine.ToString(); // 备份名称，以防我们无法解析真正的方法名称。 
        //UnityEngine.Debug.Log(methodName); //输出结果如：EditorCoroutineDemoWindow+<WaitForTwoSeconds>d__3
        string[] split = routine.ToString().Split('<', '>');
        if (split.Length == 3)
        {
            methodName = split[1];
        }

        return methodName;
    }
}