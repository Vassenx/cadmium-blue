using UnityEngine;

public class GlobalManager : MonoBehaviour
{
  public static GlobalManager Instance { get; private set; }
  public GameObject Target { get; set; }

  void Awake()
  {
    if (Instance != null) {
      Debug.LogError("There is more than one instance!");
      return;
    }

    Instance = this;
  }
}