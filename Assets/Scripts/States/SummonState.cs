using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonState : BasePlayerState
{
    [SerializeField] public BasePlayerState lastStateOfOtherWorld; 
    private BasePlayerState nextState;

    [SerializeField] private Image loadingScreen;
    [SerializeField] private Canvas persistentCanvas;
    private List<Transform> hiddenUI;
    
    private bool wasSummoned = false;

    private void Start()
    {
        LevelManager.Instance.SceneFinishedLoading += OnFinishLoadScene;
        nextState = lastStateOfOtherWorld;
        hiddenUI = new List<Transform>();
    }

    private void OnDestroy()
    {
        LevelManager.Instance.SceneFinishedLoading -= OnFinishLoadScene;
    }

    public override void Enter()
    {
        base.Enter();

        nextState = lastStateOfOtherWorld;
        lastStateOfOtherWorld = GlobalManager.Instance.GetPlayer().GetStateMachine().prevState;
        
        StartCoroutine(LoadingScreen(3f));
    }
    
    private IEnumerator LoadingScreen(float waitTime)
    {
        HideUIDuringLoading();
        
        yield return new WaitForSeconds(waitTime);
        LevelManager.Instance.SwitchWorlds();
        wasSummoned = true;
    }

    private void OnFinishLoadScene(string sceneName) // async load scene
    {
        if (!wasSummoned)
        {
            return;
        }
        
        GlobalManager.Instance.GetPlayer().GetStateMachine().ChangeState(nextState);
        ResetUIAfterLoad();
        wasSummoned = false;
    }

    // hacky
    private void HideUIDuringLoading()
    {
        foreach (Transform childUI in persistentCanvas.transform)
        {
            if (childUI.gameObject != loadingScreen.gameObject && childUI.gameObject.activeSelf)
            {
                childUI.gameObject.SetActive(false);
                hiddenUI.Add(childUI);
            }
        }
        
        loadingScreen.gameObject.SetActive(true);
    }

    private void ResetUIAfterLoad()
    {
        foreach (Transform childUI in hiddenUI)
        {
            childUI.gameObject.SetActive(true);
        }
        
        hiddenUI.Clear();
        
        loadingScreen.gameObject.SetActive(false);
    }
}
