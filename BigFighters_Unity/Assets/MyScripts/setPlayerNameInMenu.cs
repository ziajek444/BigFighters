using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setPlayerNameInMenu : MonoBehaviour
{
    public GameObject[] dataContainerGameObjList;

    void Start()
    {
        dataContainerGameObjList = GameObject.FindGameObjectsWithTag("DataContainer");
        foreach (GameObject obj in dataContainerGameObjList)
        {
            if (obj.gameObject.GetComponent<CommonData>().GetDataContainerName() == "CommonData_1")
            {
                gameObject.GetComponent<Text>().text = obj.GetComponent<CommonData>().GetPlayerName();
                break;
            } 
        }
        
    }
}
