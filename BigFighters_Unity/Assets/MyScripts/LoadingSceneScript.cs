
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class LoadingSceneScript : MonoBehaviour
{
    private CommonData commonData_1;
    public SingleLoader singleLoader;

    void Start()
    {
        GetSingleLoader();
        GetCommonData();
        singleLoader.LoadSceneByName(commonData_1.GetCurrentSceneName());
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void GetCommonData()
    {
        bool foundOne = false;
        if (commonData_1 == null)
        {
            CommonData[] arr = FindObjectsOfType<CommonData>();
            foreach (var cd in arr)
            {
                if (cd.name == "CommonData_1")
                {
                    commonData_1 = cd;
                    foundOne = true;
                    break;
                }
            }
            if (!foundOne) Debug.LogException(new Exception("Missing CommonData"), this);
        }
    }

    private void GetSingleLoader()
    {
        bool foundOne = false;
        if (singleLoader == null)
        {
            SingleLoader[] arr = FindObjectsOfType<SingleLoader>();
            foreach (var sl in arr)
            {
                if (sl.name == "SingleLoader")
                {
                    singleLoader = sl;
                    foundOne = true;
                    break;
                }
            }
            if(!foundOne) Debug.LogException(new Exception("Missing SingleLoader"), this);
        }
    }
}
