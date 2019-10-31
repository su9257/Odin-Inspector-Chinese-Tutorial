
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class EditorCoroutine : ICoroutine
{
    private IYield currentYield;
    private bool finished;
    private readonly IEnumerator enumerator;
    private readonly int ownerHash;
    private readonly string id;

    IYield ICoroutine.CurrentYield { get { return currentYield; } set { currentYield = value; } }
    bool ICoroutine.Finished { get { return finished; }set { finished = value; } }

    IEnumerator ICoroutine.GetEnumerator => enumerator;
    int ICoroutine.OwnerHash => ownerHash;
    string ICoroutine.Id => id;

    internal EditorCoroutine(int ownerHash, IEnumerator routine, string id)
    {
        currentYield = new Yield.Default();
        finished = false;

        this.enumerator = routine ?? throw new ArgumentNullException(nameof(routine), "运行时不能为null.");
        this.ownerHash = ownerHash;
        this.id = id;
    }

    void ICoroutine.Check()
    {
        object current = enumerator.Current;
        switch (current)
        {
            case null:
            case WaitForFixedUpdate _:
            case WaitForEndOfFrame _:
                currentYield = new Yield.WaitForFrames(1);
                break;
            case WaitForSeconds waitForSeconds:
                const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
                FieldInfo field = typeof(WaitForSeconds).GetField("m_Seconds", bindingFlags);
                // 如果内部 m_Seconds 字段不变就可以获取到
                if (field != null)
                {
                    float seconds = float.Parse(field.GetValue(waitForSeconds).ToString());
                    currentYield = new Yield.WaitForSeconds(seconds);
                }
                // 除非Unity在WaitForSeconds中更改了内部变量的命名，在这种情况下，我们使用Yield.Default。
                else
                {
                    currentYield = new Yield.Default();
                }

                break;
            case AsyncOperation asyncOperation:
                currentYield = new Yield.AsyncOperation(asyncOperation);
                break;
            case CustomYieldInstruction customYieldInstruction:
                currentYield = new Yield.CustomYieldInstruction(customYieldInstruction);
                break;
            case EditorCoroutine coroutine:
                currentYield = new Yield.NestedCoroutine(coroutine);
                break;
            default:
                currentYield = new Yield.Default();
                break;
        }
    }

    /// <summary>
    /// 定指定的对象是否与此EditorCoroutine相同。
    /// </summary>
    public override bool Equals(object obj)
    {
        if (obj is ICoroutine coroutine)
        {
            return id == coroutine.Id;
        }

        return false;
    }

    /// <summary>
    /// 此EditorCoroutine对应ID的散列代码。
    /// </summary>
    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
    public override string ToString()
    {
        return id;
    }
}