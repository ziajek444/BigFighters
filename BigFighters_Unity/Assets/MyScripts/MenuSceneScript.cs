using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneScript : MonoBehaviour
{
    [SerializeField] CommonData commonData_1;
    [SerializeField] Button[] buttons; 
    void Start()
    {
        commonData_1 = null;
        foreach (Button button in buttons)
        {
            button.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (commonData_1 == null)
        {
            GameObject[] dataContainerGameObjList = GameObject.FindGameObjectsWithTag("DataContainer");
            foreach(GameObject gameObj in dataContainerGameObjList) {
                if (gameObj.name == "CommonData_1")
                {
                    commonData_1 = gameObj.GetComponent<CommonData>();
                    break;
                }
            }
        }
        else if (buttons[0].enabled == false)
        {
            foreach (Button button in buttons)
            {
                button.enabled = true;
            }
        }

    }

    public void OptionScene()
    {
        SceneManager.LoadScene((int)Scene.Options);
    }
}
