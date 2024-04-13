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
  public int DTaskState = 0; // 0 = gather, 1 = prep, 2 = cook, 3 = stop-cook
  public Dictionary<Meal, int> CompletedMeals = new Dictionary<Meal, int>(); // 0 = failed, 1 = good, 2 = great
  public float CookTime = 0;
	public List<Meal> Menu;
  public bool AtHome = true;
  [SerializeField] private Player player;
  [SerializeField] private SummonState summonState;
  
  void Awake()
  {
    if (Instance != null) {
      Debug.LogError("There is more than one instance!");
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  void FixedUpdate() {
    if (CookTime > 0) {
        CookTime -= Time.deltaTime;
    } 
  }

  void Update()
  {
	  // TODO: testing
	  if (Input.GetKeyDown(KeyCode.M))
	  {
		  player.GetStateMachine().ChangeState(summonState);
	  }

      if (Input.GetKeyDown(KeyCode.N))
      {
          var timer = GameObject.FindObjectOfType<CookTimer>();
          timer.StartTimer(2f, 5f, 45f);
      }
  }
}