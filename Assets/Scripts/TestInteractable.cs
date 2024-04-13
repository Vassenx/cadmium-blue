using UnityEngine;

public class TestInteractable : MonoBehaviour, Interactable
{
    void Awake() {
        GlobalManager.Instance.Target = gameObject;
    }
    public void Interact() {
        Debug.Log("Interacting with test object!");
    }
}
