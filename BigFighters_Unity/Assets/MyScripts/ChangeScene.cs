using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    //[SerializeField] private Scene nextScene;
    private GameObject dataContainer;
    [SerializeField] private CommonData commonData_1;
    [SerializeField] private bool loadingStarted;

    private void Start()
    {
        //PrepareInitialData();

        loadingStarted = false;
    }

    private void Update()
    {
        if (!loadingStarted && !commonData_1.GetGameStarted())
        {
            loadingStarted = true;
            StartCoroutine(AsynchronousLoad(commonData_1.GetCurrentSceneNum()));
            commonData_1.SetGameStarted();
        }
    }

    public void GoLoadScene(Scene _nextScene)
    {
        /*if (nextScene == Scene.ChampionSelect)
        {
            SceneManager.LoadScene((int)nextScene);
        }
        if (commonData_1.GetChampionPrefab() != null)
        {
            SceneManager.LoadSceneAsync((int)nextScene);
        }
        else
        {
            Debug.LogException(new Exception("You must to chose champion at first!"), this);
        }*/


        //Debug.Log("Try load scene !! " + ((Scene)_nextScene).ToString());

        //SceneManager.LoadSceneAsync((int)_nextScene);
        //SceneManager.LoadScene((int)_nextScene);
        //StartCoroutine(AsynchronousLoad(_nextScene));
    }

    public IEnumerator AsynchronousLoad(int _nextScene)
    {
        yield return null;
        Debug.Log("Laduje " + ((Scene)(_nextScene)).ToString());
        AsyncOperation operation = SceneManager.LoadSceneAsync(_nextScene, LoadSceneMode.Single);
        operation.allowSceneActivation = false;
        float progress = 0f;

        while (progress < 0.9f)
        {
        progress = Mathf.Clamp01(operation.progress / 0.9f);
        yield return null;
        }
        operation.allowSceneActivation = true;
        yield return null;
    }

    private void PrepareInitialData()
    {
        commonData_1 = null;
        GameObject[] dataContainerGameObjList = GameObject.FindGameObjectsWithTag("DataContainer");
        
        if (dataContainerGameObjList.Length != 1)
        {
            if (dataContainerGameObjList.Length > 1)
            {
                Debug.LogException(new Exception("Too much DataContainers in Hierarchy" + dataContainerGameObjList.Length.ToString()), this);
            }
            else
            {
                Debug.LogException(new Exception("Too few DataContainers in Hierarchy" + dataContainerGameObjList.Length.ToString()), this);
            }
        }
        dataContainer = dataContainerGameObjList[0];
        if (!dataContainer)
        {
             Debug.LogException(new Exception("Data container does not exist"), this);
        }
        commonData_1 = dataContainer.GetComponent<CommonData>();
        if (!commonData_1)
        {
            Debug.LogException(new Exception("Data container does not contain CommonData component"), this);
        }
    }
}
