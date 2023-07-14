
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.UIElements;
using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine.Networking.Types;

public class testScript : MonoBehaviour
{
    public GameObject loadingPanel;
    [SerializeField] private progressBarScript progressBar;


    private UnityEngine.AsyncOperation loadOperation;
    private float currentValue;
    private float targetValue;

    void Start()
    {

        loadingPanel.SetActive(false);
        // Set 0 for progress values.
        progressBar.SetPercent(0f);
        currentValue = targetValue = 0f;
        // Load the next scene.
        //var currentScene = SceneManager.GetActiveScene();
        //loadOperation = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        loadOperation = SceneManager.LoadSceneAsync(7);
        // Don't active the scene when it's fully loaded, let the progress bar finish the animation.
        // With this flag set, progress will stop at 0.9f.
        loadOperation.allowSceneActivation = false;
    }

    public void quitApp()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

    private void Update()
    {
        // Assign current load progress, divide by 0.9f to stretch it to values between 0 and 1.
        targetValue = loadOperation.progress / 0.9f;
        // Calculate progress value to display.
        currentValue = Mathf.MoveTowards(currentValue, targetValue, 0.15f * Time.deltaTime);
        progressBar.SetPercent(currentValue);
        // When the progress reaches 1, allow the process to finish by setting the scene activation flag.
        if (Mathf.Approximately(currentValue, 1))
        {
            loadOperation.allowSceneActivation = true;
        }
    }
}
