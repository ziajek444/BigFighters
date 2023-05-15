using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    //[SerializeField] private Scene nextScene;
    private GameObject dataContainer;
    private CommonData commonData_1;

    private void Start()
    {
        PrepareInitialData();
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


        Debug.Log("Try load scene !! " + ((Scene)_nextScene).ToString());

        //SceneManager.LoadSceneAsync((int)_nextScene);
        //SceneManager.LoadScene((int)_nextScene);
        StartCoroutine(AsynchronousLoad(_nextScene));
    }

    public IEnumerator AsynchronousLoad(Scene _nextScene)
    {
        Debug.Log("Co sie dzieje?");
        yield return null;
        Debug.Log("Idziem dalej ");

        AsyncOperation operation = SceneManager.LoadSceneAsync((int)_nextScene);
        operation.allowSceneActivation = false;
        float progress = 0f;

        //while (!operation.isDone)
        while (progress < 0.9f)
        {
            // [0, 0.9] > [0, 1]
            progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            /*if (operation.progress == 0.9f)
            {
                Debug.Log("Press a key to start");
                if (Input.anyKeyDown)
                    operation.allowSceneActivation = true;
            }*/

            yield return null;
        }
        operation.allowSceneActivation = true;
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
