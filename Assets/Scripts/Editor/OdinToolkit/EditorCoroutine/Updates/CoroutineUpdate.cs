using System.Collections.Generic;
using System.Linq;

internal class CoroutineUpdate<T> : IUpdateService<T> where T : ICoroutine
{
    // 储存 协程所有运行实例的Id。
    private readonly Dictionary<string, List<T>> runningCoroutines;
    public CoroutineUpdate()
    {
        runningCoroutines = new Dictionary<string, List<T>>();
    }


    #region START/STOP

    public T StartCoroutine(T coroutine)
    {
        if (!runningCoroutines.ContainsKey(coroutine.Id))
        {
            runningCoroutines[coroutine.Id] = new List<T>();
        }

        runningCoroutines[coroutine.Id].Add(coroutine);

        if (coroutine.GetEnumerator.MoveNext())
        {
            coroutine.Check();
        }
        return coroutine;
    }

    public void StopCoroutine(string coroutineId)
    {
        runningCoroutines.Remove(coroutineId);
    }

    public void StopCoroutine(T coroutine)
    {
        runningCoroutines.Remove(coroutine.Id);
    }

    /// <summary>
    /// 移除所有符合指定 ownerHash的协程
    /// </summary>
    /// <param name="ownerHash"></param>
    public void StopAllCoroutines(int ownerHash)
    {
        foreach (KeyValuePair<string, List<T>> coroutineInstanceListInfo in runningCoroutines.ToList())
        {
            List<T> coroutineInstanceList = coroutineInstanceListInfo.Value;
            coroutineInstanceList.RemoveAll((coroutine) =>
            {
                return coroutine.OwnerHash == ownerHash;
            });

            if (coroutineInstanceList.Count == 0)
            {
                runningCoroutines.Remove(coroutineInstanceListInfo.Key);
            }
        }
    }
    /// <summary>
    /// 移除所有协程
    /// </summary>
    public void StopAllCoroutines()
    {
        runningCoroutines.Clear();
    }

    #endregion START/STOP


    #region UPDATE

    public void Update(double deltaTime, int deltaFrames)
    {
        if (runningCoroutines.Count == 0)
        {
            return;
        }
        /*
         * 下面使用 runningCoroutines.ToList() 而不是简单的 runningCoroutines。
            这是为了缓存 runningCoroutines的当前列表，并仅对那些列表进行评估，以防在评估当前集合时启动另一个ICoroutine。
         */
        foreach (KeyValuePair<string, List<T>> coroutineListInfo in runningCoroutines.ToList())
        {
            List<T> coroutineList = coroutineListInfo.Value;
            for (int i = coroutineList.Count - 1; i >= 0; i--) //倒叙，以允许在迭代期间删除元素。
            {
                T coroutine = coroutineList[i];

                if (!coroutine.CurrentYield.IsReadyToYield(deltaTime, deltaFrames))
                {
                    continue;
                }

                if (coroutine.GetEnumerator.MoveNext())//如果后续还有yield
                {
                    coroutine.Check();//获取对应的yield
                    continue;
                }

                coroutineList.RemoveAt(i);
                coroutine.CurrentYield = null;
                coroutine.Finished = true;
            }

            if (coroutineList.Count == 0)
            {
                runningCoroutines.Remove(coroutineListInfo.Key);
            }
        }
    }

    #endregion UPDATE
}
