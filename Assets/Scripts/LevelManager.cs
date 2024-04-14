using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private Canvas persistentCanvas;
    
    public event Action<string> SceneFinishedLoading;
    
    private bool hasStarted = false;

    public List<AudioClip> HumanSongs;

    public List<AudioClip> DemonSongs;

    [SerializeField]
    private AudioSource audioSource;

    private int currentIterationHuman = 0;
    private int currentIterationDemon = 0;

    #region singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
        
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(persistentCanvas);
    }
    #endregion

    public void Update()
    {
        // for dontdestroyonload shenanigans
        if(!hasStarted && SceneManager.GetActiveScene().name.Equals("StartWorld"))
        {
            StartCoroutine(LoadAsyncScene("Demon"));
            hasStarted = true;
        }
    }

    public void SwitchWorlds()
    {
        if (SceneManager.GetActiveScene().name.Equals("Demon"))
        {
            audioSource.clip = HumanSongs[currentIterationHuman%HumanSongs.Count];
            currentIterationHuman++;
            audioSource.Play();
            StartCoroutine(LoadAsyncScene("Human"));
        }
        else if(SceneManager.GetActiveScene().name.Equals("Human"))
        {
            audioSource.clip = DemonSongs[currentIterationDemon%DemonSongs.Count];
            currentIterationDemon++;
            audioSource.Play();
            StartCoroutine(LoadAsyncScene("Demon"));
        }
    }
    
    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
            if (SceneFinishedLoading != null)
            {
                SceneFinishedLoading(sceneName);
            }
        }
    }
}
