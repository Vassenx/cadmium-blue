using UnityEngine;

public class TestInteractable : MonoBehaviour, Interactable
{
    public void Interact() {
        Debug.Log("Interacting with test object!");
    }
}
