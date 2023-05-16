using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CommonData : MonoBehaviour
{
    #region Data
    // TODO remove [SerializeFierld], used only for debug purpose
    [SerializeField] private string containerName;
    [SerializeField] private GameObject championPrefab;
    [SerializeField] private string playerName;
    [SerializeField] private Text playerNameTextField;
    [SerializeField] private int previousSceneNum=0;
    [SerializeField] private string previousSceneName="Loading";
    [SerializeField] private int currentSceneNum=1;
    [SerializeField] private string currentSceneName="Menu";
    private bool isGameStarted = false;

    #endregion

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DataContainer");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

#region Set Common Data
    public void SetChampionPrefab(GameObject newChampionPrefab)
    {
        championPrefab = newChampionPrefab;
    }

    public void UpdatePlayerName()
    {
        playerName = playerNameTextField.text;

        string secretName = playerName;
        for(int i = 0; i < 4; i++)
        {
            int secretInt = Random.Range(0, 99);
            secretName += secretInt.ToString();
        }
        playerName = secretName;
    }

    public void UpdateSceneData(int nextSceneNum)
    {
        previousSceneNum = currentSceneNum;
        previousSceneName = currentSceneName;
        currentSceneNum = nextSceneNum;
        currentSceneName = ((Scene)nextSceneNum).ToString();
    }

    public void SetBackScene()
    {
        var nextSceneNum = previousSceneNum;
        var nextSceneName = previousSceneName;
        previousSceneNum = currentSceneNum;
        previousSceneName = currentSceneName;
        currentSceneNum = nextSceneNum;
        currentSceneName = nextSceneName;
    }

    public void SetGameStarted()
    {
        isGameStarted = true;
    }
#endregion

#region get Common Data
    public GameObject GetChampionPrefab()
    {
        return championPrefab;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public string GetDataContainerName()
    {
        return containerName;
    }

    public int GetPreviousSceneNum()
    {
        return previousSceneNum;
    }

    public int GetCurrentSceneNum()
    {
        return currentSceneNum;
    }

    public string GetPreviousSceneName()
    {
        return previousSceneName;
    }

    public string GetCurrentSceneName()
    {
        return currentSceneName;
    }

    public bool GetGameStarted()
    {
        return isGameStarted;
    }

    #endregion
}
