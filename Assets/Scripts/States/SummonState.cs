using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SummonState : BasePlayerState
{
    [SerializeField] public Player player;
    [SerializeField] public BasePlayerState lastStateOfOtherWorld; 
    private BasePlayerState nextState;

    [SerializeField] private Image loadingScreen;

    private void Start()
    {
        LevelManager.Instance.SceneFinishedLoading += OnFinishLoadScene;
        nextState = lastStateOfOtherWorld;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.SceneFinishedLoading -= OnFinishLoadScene;
    }

    public override void Enter()
    {
        base.Enter();

        nextState = lastStateOfOtherWorld;
        lastStateOfOtherWorld = player.GetStateMachine().prevState;
        
        StartCoroutine(LoadingScreen(3f));
    }
    
    private IEnumerator LoadingScreen(float waitTime)
    {
        loadingScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        LevelManager.Instance.SwitchWorlds();
    }

    private void OnFinishLoadScene(string sceneName) // async load scene
    {
        player.GetStateMachine().ChangeState(nextState);
        loadingScreen.gameObject.SetActive(false);
    }
}
