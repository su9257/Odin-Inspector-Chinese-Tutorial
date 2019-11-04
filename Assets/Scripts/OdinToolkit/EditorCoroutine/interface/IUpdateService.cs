
    /// <summary>
    /// 启动关闭等相关函数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IUpdateService<T> where T : ICoroutine
    {
        T StartCoroutine (T coroutine);

        void StopCoroutine (string coroutineId);

        void StopCoroutine (T coroutine);

        void StopAllCoroutines (int ownerHash);

        void StopAllCoroutines ();

        void Update (double deltaTime, int deltaFrames);
    }

