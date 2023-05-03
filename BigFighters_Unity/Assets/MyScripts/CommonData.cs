using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonData : MonoBehaviour
{
#region Data
    // TODO remove [SerializeFierld], used only for debug purpose
    [SerializeField] private GameObject championPrefab;
    [SerializeField] private string playerName;
    [SerializeField] private Text playerNameTextField;
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
            int secretInt = Random.Range(0, 9999);
            secretName += secretInt.ToString();
        }
        playerName = secretName;
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
#endregion
}
