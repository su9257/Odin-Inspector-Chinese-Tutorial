
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using Sirenix.OdinInspector;
public class EditorCoroutineDemo : SerializedScriptableObject
{
    private EditorCoroutine loopEveryTwoSecondsHandle;

    [TextArea(5, 15), PropertyOrder(10000)]
    [PropertySpace(30)]
    [LabelText("日志信息")]
    public string logContent;

    [Button(ButtonSizes.Large, Name = "每2秒迭代一次")]
    private void Button_0()
    {

        loopEveryTwoSecondsHandle = EditorCoroutineService.StartCoroutine(WaitForTwoSeconds());
    }
    [Button(ButtonSizes.Large, Name = "每20帧迭代一次")]
    private void Button_1()
    {
        EditorCoroutineService.StartCoroutine(WaitForTwentyFrames());
    }
    [Button(ButtonSizes.Large, Name = "UnityWebRequest等待")]
    private void Button_2()
    {
        EditorCoroutineService.StartCoroutine(WaitForUnityWebRequest());
    }
    [Button(ButtonSizes.Large, Name = "嵌套协程")]
    private void Button_3()
    {
        EditorCoroutineService.StartCoroutine(WaitForNestedCoroutines());
    }
    [Button(ButtonSizes.Large, Name = "停止没2秒迭代的协程")]
    private void Button_4()
    {
        if (loopEveryTwoSecondsHandle != null)
        {
            EditorCoroutineService.StopCoroutine(loopEveryTwoSecondsHandle);
        }
    }
    [Button(ButtonSizes.Large, Name = "停止所有协程")]
    private void Button_5()
    {
        EditorCoroutineService.StopAllCoroutines();
    }

    [Button(ButtonSizes.Large, Name = "清除日志信息")]
    public void ClearLog()
    {
        logContent = "";
    }

    private IEnumerator WaitForTwoSeconds()
    {
        while (true)
        {
            CustomLog("每2秒迭代一次");
            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator WaitForTwentyFrames()
    {
        while (true)
        {
            CustomLog("每20帧迭代一次.");
            for (int i = 0; i < 20; i++)
            {
                yield return null;
            }
        }
    }

    private IEnumerator WaitForUnityWebRequest()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get("https://unity3d.com/");
            yield return www.SendWebRequest();
            CustomLog("UnityWebRequest. " + www.downloadHandler.text);
            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator WaitForNestedCoroutines()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            CustomLog("2秒进入另一个嵌套协程.");
            yield return EditorCoroutineService.StartCoroutine(WaitForNestedCoroutinesDepthOne());
        }
    }

    private IEnumerator WaitForNestedCoroutinesDepthOne()
    {
        yield return new WaitForSeconds(2f);
        CustomLog("嵌套一层协程");
        yield return EditorCoroutineService.StartCoroutine(WaitForNestedCoroutinesDepthTwo());
    }

    private IEnumerator WaitForNestedCoroutinesDepthTwo()
    {
        yield return new WaitForSeconds(2f);
        CustomLog("嵌套二层协程");
    }

    
    public void CustomLog(string content)
    {
        logContent += "\r\n";
        logContent += content;
    }
}

