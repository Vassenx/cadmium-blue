using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
  public static GlobalManager Instance { get; private set; }
  public Dictionary<Meal, int> CompletedMeals = new Dictionary<Meal, int>(); // 0 = burnt, 1 = raw, 2 = good, 3 = great
  public List<Meal> Menu;
  public bool AtHome = true;
  [SerializeField] private Player player;
  [SerializeField] private CookTimer cookTimer;
  [SerializeField] private ResultScreen resultScreen;
  private List<BasePlayerState> states;

  public int curBattleIndex = -1;
  
  void Awake()
  {
    if (Instance != null) {
      Debug.LogError("There is more than one instance!");
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  private void Start()
  {
      states = player.GetComponentsInChildren<BasePlayerState>().ToList();
  }

  public Player GetPlayer()
  {
      return player;
  }

  public BasePlayerState GetStateByName(string stateName)
  {
      foreach (BasePlayerState state in states)
      {
          if (state.GetStateName().Equals(stateName))
          {
              return state;
          }
      }

      return null;
  }

  public void SummonPlayer()
  {
      player.GetStateMachine().ChangeState(GetStateByName("Summon"));
  }

  public CookTimer GetCookTimer()
  {
      return cookTimer;
  }

  void Update()
  {
	  // TODO: testing
	  if (Input.GetKeyDown(KeyCode.M))
	  {
          SummonPlayer();
	  }

      if (Input.GetKeyDown(KeyCode.N))
      {
          var timer = GameObject.FindObjectOfType<CookTimer>();
          timer.StartTimer(2f, 5f, 45f);
      }

      if (Input.GetKeyDown(KeyCode.B))
      {
          GameObject.FindObjectOfType<WaveManager>().OnEnemyDeath();
      }
  }

  public void ShowResultScreen(Meal meal)
  {
      CompletedMeals.TryGetValue(meal, out int mealQuality);
      StartCoroutine(resultScreen.ShowResultScreen(meal, mealQuality));
  }
    
}