using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{
    [SerializeField] CommonData commonData_1 = null;
    void Start()
    {
        if (commonData_1 == null)
        {
            Debug.LogException(new Exception("commonData load not fast enough"), this);
        }
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LOADING")
        {
            SceneManager.LoadScene((int)Scene.Menu);
        }
    }
}
