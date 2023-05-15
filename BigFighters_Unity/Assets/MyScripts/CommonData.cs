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
    [SerializeField] private int previousSceneNum;
    [SerializeField] private string previousSceneName;
    [SerializeField] private int currentSceneNum;
    [SerializeField] private string currentSceneName;
    [SerializeField] private bool runTheGame = true;

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
        previousSceneNum = -1;
        previousSceneName = "NONE";
        currentSceneNum = 0;
        currentSceneName = ((Scene)currentSceneNum).ToString();
        runTheGame = false;
        ChangeScene changeScene = FindObjectOfType<ChangeScene>();
        //changeScene.GoLoadScene(Scene.Game);
        Debug.Log("Startuje async");
        StartCoroutine(changeScene.AsynchronousLoad(Scene.Game));
        
        Debug.Log("Chyba jeszcze dziala");
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
            int secretInt = Random.Range(0, 9999);
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
    #endregion
}
