using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ChampionHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
#region Variables
    private GameObject dataContainer;
    private CommonData commonData_1;
    private Image hoverColorImage;
    private bool isActive;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color activeColor;
    public GameObject championPrefab;
#endregion

    // Start is called before the first frame update
    void Start()
    {
        PrepareInitialData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#region Pointer interface
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetImageIconRefFromEventData(eventData);
        if(IsImageRefExist())
        {
            if (!isActive)
            {
                SetHoverColor();
            }
        }
        else
        {
            Debug.LogException(new Exception("Image Component does not exists."), this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(IsImageRefExist())
        {
            if (!isActive)
            {
                SetDefaultColor();
            }
        }
        else
        {
            Debug.LogException(new Exception("Image Component does not exists."), this);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameObject[] allChampHolders = GameObject.FindGameObjectsWithTag("championHolderTag");
        foreach (GameObject champHolder in allChampHolders)
        {
            //champHolder.transform.Find("bg/hoverColor").gameObject.GetComponent<Image>().color = defaultColor;
            if (champHolder.gameObject.GetComponent<ChampionHolder>().IsActive())
            {
                champHolder.gameObject.GetComponent<ChampionHolder>().Deactivate();
            }
        }
        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            commonData_1.SetChampionPrefab(championPrefab);
            if(IsImageRefExist())
            {
                SetActiveColor();
            }
            else
            {
                Debug.LogException(new Exception("Image Component does not exists."), this);
            }
        }
    }
#endregion

    // PRIVATE
    private void GetImageIconRefFromEventData(PointerEventData eventData)
    {
        if (!hoverColorImage)
        {
            hoverColorImage = eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>();
        }
    }

    private void SetHoverColor()
    {
        hoverColorImage.color = hoverColor;
    }

    private void SetDefaultColor()
    {
        hoverColorImage.color = defaultColor;
    }

    private void SetActiveColor()
    {
        isActive = true;
        hoverColorImage.color = activeColor;
    }

    private bool IsImageRefExist()
    {
        return hoverColorImage != null;
    }

    // PUBLIC
    public void Deactivate()
    {
        isActive = false;
        if(IsImageRefExist())
        {
            SetDefaultColor();
        }
        else
        {
            Debug.LogException(new Exception("Image Component does not exists."), this);
        }
    }

    public bool IsActive()
    {
        return isActive;
    }

    // INTERNAL
    private void PrepareInitialData()
    {
        isActive = false;
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
        hoverColorImage = null;
    }
}
