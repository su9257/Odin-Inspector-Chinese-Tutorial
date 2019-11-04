using System.Collections;


    internal interface ICoroutineFactory<out T> where T : ICoroutine
    {
        T Create (object owner, IEnumerator routine);

        string CreateId (object owner, IEnumerator routine);

        string CreateId (object owner, string methodName);

        string CreateId (int ownerHash, IEnumerator routine);

        string CreateId (int ownerHash, string methodName);

        int GetOwnerHash (object owner);

        string GetCoreMethodName (IEnumerator routine);
    }

