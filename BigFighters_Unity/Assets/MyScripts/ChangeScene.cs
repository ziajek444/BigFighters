using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Scene nextScene;
    private GameObject dataContainer;
    private CommonData commonData_1;

    private void Start()
    {
        PrepareInitialData();
    }

    public void GoLoadScene()
    {
        if (nextScene == Scene.ChampionSelect)
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
        }
    }

    private void PrepareInitialData()
    {
        commonData_1 = null;
        GameObject[] dataContainerGameObjList = GameObject.FindGameObjectsWithTag("DataContainer");
        
        if (dataContainerGameObjList.Length != 1)
        {
            if (dataContainerGameObjList.Length > 1)
            {
                Debug.LogException(new Exception("Too much DataContainers in Hierarchy"), this);
            }
            else
            {
                Debug.LogException(new Exception("Too few DataContainers in Hierarchy"), this);
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
