using UnityEditor;

internal class EditorCoroutineUpdate : IUpdateService<EditorCoroutine>
{
    private readonly IUpdateService<EditorCoroutine> coreUpdateService;
    public double PreviousTimeSinceStartup { get; set; }

    public EditorCoroutineUpdate()
    {
        coreUpdateService = new CoroutineUpdate<EditorCoroutine>();
    }

    public void OnUpdate()
    {
        double deltaTime = EditorApplication.timeSinceStartup - PreviousTimeSinceStartup;
        PreviousTimeSinceStartup = EditorApplication.timeSinceStartup;
        Update(deltaTime, 1);
    }

    public EditorCoroutine StartCoroutine(EditorCoroutine coroutine)
    {
        return coreUpdateService.StartCoroutine(coroutine);
    }

    public void StopCoroutine(string coroutineId)
    {
        coreUpdateService.StopCoroutine(coroutineId);
    }

    public void StopCoroutine(EditorCoroutine coroutine)
    {
        coreUpdateService.StopCoroutine(coroutine);
    }

    public void StopAllCoroutines(int ownerHash)
    {
        coreUpdateService.StopAllCoroutines(ownerHash);
    }

    public void StopAllCoroutines()
    {
        coreUpdateService.StopAllCoroutines();
    }

    public void Update(double deltaTime, int deltaFrames)
    {
        coreUpdateService.Update(deltaTime, deltaFrames);
    }
}