using System.Collections;
internal interface ICoroutine
{
    IYield CurrentYield { get; set; }
    bool Finished { get; set; }
    IEnumerator GetEnumerator { get; }
    int OwnerHash { get; }
    string Id { get; }
    void Check();
}

