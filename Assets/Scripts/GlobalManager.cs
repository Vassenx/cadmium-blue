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

  void Awake()
  {
    if (Instance != null) {
      Debug.LogError("There is more than one instance!");
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadJson();
  }

  void FixedUpdate() {
    if (CookTime > 0) {
        CookTime -= Time.deltaTime;
    }
	}

  void Update() {
    if (!AtHome && SceneManager.GetActiveScene().name == "Demon") {
      SceneManager.LoadScene("Human");
    }
  }

	public void LoadJson()
    {
			using (StreamReader r = new StreamReader("Assets/Scripts/Meals.json"))
			{
				string json = r.ReadToEnd();
				Menu = JsonConvert.DeserializeObject<List<Meal>>(json);
			}
    }
}

public class Meal
{
	public string name;
	public string gatherLocation;
	public string prepLocation;
	public float cookTime;
	public float greatThreshold;
	public float goodThreshold;
  public int breakPoint; // -1 = do not interrupt, 0-3 = summon to Human world
}