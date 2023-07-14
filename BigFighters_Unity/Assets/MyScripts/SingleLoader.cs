using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLoader : MonoBehaviour
{
    public static SingleLoader Instance;
    public float progrss;
    [SerializeField] GameObject trigger;
    public progressBarScript progressBar;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        // enable canvas loader
        progrss = 0f;
        progressBar.SetPercent(1f);

        do {
            await Task.Delay(100);
            progrss = scene.progress;
            progressBar.SetPercent(scene.progress*110f);
        } while (scene.progress < 0.9f);

        progrss = 1f;
        progressBar.SetPercent(100f);
        await Task.Delay(1000);

        scene.allowSceneActivation = true;
    }

    private IEnumerator ienumLoadSceneByName(string sceneName)
    {
        LoadScene(sceneName);
        yield return null;
    }

    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(ienumLoadSceneByName(sceneName));
    }
}
