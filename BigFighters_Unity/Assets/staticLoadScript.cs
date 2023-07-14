using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class staticLoadScript
{
    private class LoadScriptMonoBehaviour : MonoBehaviour { }
    private static AsyncOperation operation = null;
    private static Action onLoaderCallback = null;
    private static bool expectedCallBack = false;
    

    public static void LoadSceneById(Scene newScene)
    {
        expectedCallBack = true;
        onLoaderCallback = () =>
        {
            GameObject loadingGameObj = new GameObject("Loading Game Obj");
            loadingGameObj.AddComponent<LoadScriptMonoBehaviour>().StartCoroutine(CoroutineLoad(newScene));
        };
    }

    private static IEnumerator CoroutineLoad(Scene newScene)
    {
        yield return null;
        operation = SceneManager.LoadSceneAsync((int)newScene);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public static float GetProgress()
    {
        if (operation != null)
        {
            return operation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoadScriptCallback()
    {
        if (onLoaderCallback != null && expectedCallBack == true)
        {
            onLoaderCallback();
            onLoaderCallback = null;
            expectedCallBack = false;
        }
    }
}
